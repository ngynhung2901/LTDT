using ExcelDataReader;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LTDT
{
    public partial class Form1 : Form
    {
        // =============================================================
        // KHAI BÁO CẤU TRÚC DỮ LIỆU & BIẾN TOÀN CỤC
        // =============================================================

        // Class lưu thông tin phòng thi (TÊN + DUNG LƯỢNG)
        public class RoomInfo
        {
            public string RoomName { get; set; }
            public int Capacity { get; set; }
        }

        // Class đại diện cho một môn thi (Đỉnh của đồ thị)
        public class SubjectNode
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public HashSet<string> Students { get; set; } = new HashSet<string>();
            public Dictionary<string, string> StudentNames { get; set; } = new Dictionary<string, string>();

            // ← MỚI: Lưu từng sinh viên vào phòng cụ thể
            public Dictionary<string, string> StudentRoomAssignment { get; set; } = new Dictionary<string, string>(); // MSSV -> Phòng

            public HashSet<string> Adjacent { get; set; } = new HashSet<string>();
            public int Degree => Adjacent.Count;
            public int Color { get; set; } = -1;
        }

        // Biến lưu trữ kết quả toàn cục
        Dictionary<string, SubjectNode> globalGraph = new Dictionary<string, SubjectNode>();
        Dictionary<string, string> globalRoomResult = new Dictionary<string, string>(); // Mã Môn -> Danh sách phòng (hiển thị)
        Dictionary<string, string> globalTimeResult = new Dictionary<string, string>(); // Mã Môn -> Thời gian thi

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            this.btnnhapfilesvdk.Click += BtnImportDK_Click;
            this.btnnhapfilelich.Click += BtnImportCa_Click;
            this.btnxlt.Click += Btnxlt_Click;
            
            this.btnlammoi.Click += Btnlammoi_Click;
            this.btnthoat.Click += Btnthoat_Click;

            this.dgvdangki.CellClick += Dgv_CellClick;
            this.dgvcathi.CellClick += Dgv_CellClick;
            this.dgvlichthi.CellClick += Dgv_CellClick;

            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            ToolStripMenuItem itemExportDetail = new ToolStripMenuItem("Xuất Lịch Chi Tiết Theo Sinh Viên (Excel)");
            itemExportDetail.Click += BtnExportStudentDetail_Click;
            itemExportDetail.Font = new Font(itemExportDetail.Font, FontStyle.Bold);
            itemExportDetail.ForeColor = Color.Blue;
            ctxMenu.Items.Add(itemExportDetail);
            dgvlichthi.ContextMenuStrip = ctxMenu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupDataGridViews();
            dtngaysinh.Format = DateTimePickerFormat.Custom;
            dtngaysinh.CustomFormat = "dd/MM/yyyy";
        }

        private void SetupDataGridViews()
        {
            dgvdangki.ColumnCount = 4;
            dgvdangki.Columns[0].Name = "Mã SV";
            dgvdangki.Columns[1].Name = "Tên SV";
            dgvdangki.Columns[2].Name = "Mã Môn";
            dgvdangki.Columns[3].Name = "Tên Môn";

            dgvcathi.ColumnCount = 4;
            dgvcathi.Columns[0].Name = "Ngày Thi";
            dgvcathi.Columns[1].Name = "Ca Thi (Giờ)";
            dgvcathi.Columns[2].Name = "Phòng Thi";
            dgvcathi.Columns[3].Name = "Sức Chứa";

            dgvlichthi.ColumnCount = 6;
            dgvlichthi.Columns[0].Name = "Mã Môn";
            dgvlichthi.Columns[1].Name = "Tên Môn";
            dgvlichthi.Columns[2].Name = "Ngày Thi";
            dgvlichthi.Columns[3].Name = "Ca Thi";
            dgvlichthi.Columns[4].Name = "Phòng Thi";
            dgvlichthi.Columns[5].Name = "Sĩ Số";
        }

        // =============================================================
        // PHẦN 1: NHẬP DỮ LIỆU TỪ EXCEL
        // =============================================================
        private void ImportExcelToDGV(DataGridView dgv)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xlsx;*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet();
                                if (result.Tables.Count > 0)
                                {
                                    DataTable dt = result.Tables[0];
                                    dgv.Rows.Clear();
                                    for (int i = 1; i < dt.Rows.Count; i++)
                                    {
                                        var row = dt.Rows[i];
                                        bool hasData = false;
                                        for (int c = 0; c < row.ItemArray.Length; c++)
                                            if (row[c] != null && !string.IsNullOrEmpty(row[c].ToString())) hasData = true;

                                        if (hasData)
                                        {
                                            int colCount = Math.Min(dgv.Columns.Count, row.ItemArray.Length);
                                            object[] rowData = new object[colCount];
                                            Array.Copy(row.ItemArray, rowData, colCount);
                                            dgv.Rows.Add(rowData);
                                        }
                                    }
                                    MessageBox.Show($"Đã nhập thành công {dgv.Rows.Count} dòng dữ liệu!");
                                }
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi đọc file: " + ex.Message); }
                }
            }
        }

        private void BtnImportDK_Click(object sender, EventArgs e)
        {
            tbctroldulieu.SelectedTab = tabPage2;
            ImportExcelToDGV(dgvdangki);
        }

        private void BtnImportCa_Click(object sender, EventArgs e)
        {
            tbctroldulieu.SelectedTab = tabPage3;
            ImportExcelToDGV(dgvcathi);
        }

        // =============================================================
        // PHẦN 2: THUẬT TOÁN TÔ MÀU ĐỒ THỊ + PHÂN CHIA SINH VIÊN VÀO PHÒNG
        // =============================================================
        private void Btnxlt_Click(object sender, EventArgs e)
        {
            globalGraph.Clear();
            globalRoomResult.Clear();
            globalTimeResult.Clear();
            dgvlichthi.Rows.Clear();

            // B2: Đọc tài nguyên
            Dictionary<string, List<RoomInfo>> resourceSlots = new Dictionary<string, List<RoomInfo>>();
            List<string> orderedSlotKeys = new List<string>();

            foreach (DataGridViewRow row in dgvcathi.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value == null || row.Cells[1].Value == null) continue;

                string key = $"{row.Cells[0].Value} - {row.Cells[1].Value}";
                string phong = row.Cells[2].Value?.ToString() ?? "Phòng ?";

                int dungLuong = 50;
                if (row.Cells[3].Value != null && int.TryParse(row.Cells[3].Value.ToString(), out int capacity))
                {
                    dungLuong = capacity;
                }

                if (!resourceSlots.ContainsKey(key))
                {
                    resourceSlots[key] = new List<RoomInfo>();
                    orderedSlotKeys.Add(key);
                }

                resourceSlots[key].Add(new RoomInfo { RoomName = phong, Capacity = dungLuong });
            }

            if (orderedSlotKeys.Count == 0)
            {
                MessageBox.Show("Lỗi: Bạn chưa nhập danh sách Ca Thi!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // B3: Xây dựng đồ thị
            Dictionary<string, List<string>> studentToSubjects = new Dictionary<string, List<string>>();

            foreach (DataGridViewRow row in dgvdangki.Rows)
            {
                if (row.IsNewRow) continue;
                string mssv = row.Cells[0].Value?.ToString();
                string tensv = row.Cells[1].Value?.ToString();
                string maMon = row.Cells[2].Value?.ToString();
                string tenMon = row.Cells[3].Value?.ToString();

                if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(maMon)) continue;

                if (!globalGraph.ContainsKey(maMon))
                    globalGraph[maMon] = new SubjectNode { ID = maMon, Name = tenMon };

                globalGraph[maMon].Students.Add(mssv);
                if (!globalGraph[maMon].StudentNames.ContainsKey(mssv))
                    globalGraph[maMon].StudentNames[mssv] = string.IsNullOrEmpty(tensv) ? "N/A" : tensv;

                if (!studentToSubjects.ContainsKey(mssv)) studentToSubjects[mssv] = new List<string>();
                if (!studentToSubjects[mssv].Contains(maMon)) studentToSubjects[mssv].Add(maMon);
            }

            if (globalGraph.Count == 0)
            {
                MessageBox.Show("Lỗi: Chưa có dữ liệu đăng ký!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // B4: Xác định cạnh xung đột
            foreach (var entry in studentToSubjects)
            {
                List<string> subjectsOfStudent = entry.Value;
                if (subjectsOfStudent.Count > 1)
                {
                    for (int i = 0; i < subjectsOfStudent.Count; i++)
                    {
                        for (int j = i + 1; j < subjectsOfStudent.Count; j++)
                        {
                            string monA = subjectsOfStudent[i];
                            string monB = subjectsOfStudent[j];
                            globalGraph[monA].Adjacent.Add(monB);
                            globalGraph[monB].Adjacent.Add(monA);
                        }
                    }
                }
            }

            // B5: Tô màu đồ thị + Phân chia sinh viên vào phòng
            var sortedSub = globalGraph.Values.OrderByDescending(s => s.Degree).ToList();

            int colorIndex = 0;
            int processedCount = 0;
            List<string> warningMessages = new List<string>();

            while (processedCount < sortedSub.Count && colorIndex < orderedSlotKeys.Count)
            {
                string currentSlotKey = orderedSlotKeys[colorIndex];
                var availableRooms = new List<RoomInfo>(resourceSlots[currentSlotKey].OrderByDescending(r => r.Capacity));

                List<SubjectNode> assignedSubjects = new List<SubjectNode>();

                foreach (var sub in sortedSub)
                {
                    if (sub.Color == -1)
                    {
                        bool isConflict = false;
                        foreach (string neighborID in sub.Adjacent)
                        {
                            if (globalGraph[neighborID].Color == colorIndex)
                            {
                                isConflict = true;
                                break;
                            }
                        }

                        if (!isConflict)
                        {
                            sub.Color = colorIndex;
                            assignedSubjects.Add(sub);
                            processedCount++;
                        }
                    }
                }

                // GÁN PHÒNG VÀ PHÂN CHIA SINH VIÊN
                assignedSubjects = assignedSubjects.OrderByDescending(s => s.Students.Count).ToList();

                foreach (var sub in assignedSubjects)
                {
                    int studentCount = sub.Students.Count;
                    List<string> assignedRoomsList = new List<string>();
                    var studentList = sub.Students.ToList(); // Chuyển HashSet thành List để dễ chia
                    int studentIndex = 0; // Index để theo dõi SV đã phân

                    // Tìm phòng vừa đủ trước
                    var perfectRoom = availableRooms.Where(r => r.Capacity >= studentCount)
                                                     .OrderBy(r => r.Capacity)
                                                     .FirstOrDefault();

                    if (perfectRoom != null)
                    {
                        // Có phòng vừa đủ → Xếp tất cả SV vào 1 phòng
                        assignedRoomsList.Add(perfectRoom.RoomName);

                        // ← PHÂN CHIA: Tất cả SV vào phòng này
                        for (int i = 0; i < studentCount; i++)
                        {
                            sub.StudentRoomAssignment[studentList[i]] = perfectRoom.RoomName;
                        }

                        availableRooms.Remove(perfectRoom);
                        globalRoomResult[sub.ID] = perfectRoom.RoomName;
                        globalTimeResult[sub.ID] = currentSlotKey;
                    }
                    else
                    {
                        // Ghép nhiều phòng
                        int remainingStudents = studentCount;

                        while (remainingStudents > 0 && availableRooms.Count > 0)
                        {
                            var room = availableRooms.OrderByDescending(r => r.Capacity).First();
                            assignedRoomsList.Add(room.RoomName);

                            // ← PHÂN CHIA: Chia SV vào từng phòng theo dung lượng
                            int studentsForThisRoom = Math.Min(room.Capacity, remainingStudents);
                            for (int i = 0; i < studentsForThisRoom; i++)
                            {
                                if (studentIndex < studentList.Count)
                                {
                                    sub.StudentRoomAssignment[studentList[studentIndex]] = room.RoomName;
                                    studentIndex++;
                                }
                            }

                            remainingStudents -= room.Capacity;
                            availableRooms.Remove(room);
                        }

                        if (remainingStudents > 0)
                        {
                            warningMessages.Add($"❌ Môn {sub.Name} ({sub.ID}): Cần {studentCount} chỗ nhưng ca này chỉ còn {studentCount - remainingStudents} chỗ!");
                            sub.Color = -1;
                            processedCount--;

                            // Hoàn trả phòng
                            foreach (var roomName in assignedRoomsList)
                            {
                                var roomInfo = resourceSlots[currentSlotKey].FirstOrDefault(r => r.RoomName == roomName);
                                if (roomInfo != null) availableRooms.Add(roomInfo);
                            }
                            sub.StudentRoomAssignment.Clear(); // Xóa phân bổ SV
                        }
                        else
                        {
                            string roomsStr = string.Join(", ", assignedRoomsList);
                            globalRoomResult[sub.ID] = roomsStr;
                            globalTimeResult[sub.ID] = currentSlotKey;

                            if (assignedRoomsList.Count > 1)
                            {
                                // Tạo thông tin chi tiết từng phòng
                                var roomDetails = assignedRoomsList.Select(r => {
                                    int count = sub.StudentRoomAssignment.Count(kv => kv.Value == r);
                                    return $"{r} ({count} SV)";
                                });
                                warningMessages.Add($"ℹ️ Môn {sub.Name}: {studentCount} SV → {assignedRoomsList.Count} phòng: {string.Join(", ", roomDetails)}");
                            }
                        }
                    }
                }

                colorIndex++;
            }

            // B6: Hiển thị kết quả
            List<string> failedSubjects = new List<string>();

            foreach (var sub in globalGraph.Values)
            {
                if (sub.Color != -1 && globalRoomResult.ContainsKey(sub.ID))
                {
                    string timeInfo = globalTimeResult[sub.ID];
                    string[] parts = timeInfo.Split(new string[] { " - " }, StringSplitOptions.None);
                    string assignedRoom = globalRoomResult[sub.ID];

                    dgvlichthi.Rows.Add(sub.ID, sub.Name, parts[0],
                                        (parts.Length > 1 ? parts[1] : ""),
                                        assignedRoom, sub.Students.Count);
                }
                else
                {
                    failedSubjects.Add($"{sub.ID} - {sub.Name} ({sub.Students.Count} SV, Bậc: {sub.Degree})");
                }
            }

            tbctroldulieu.SelectedTab = tabPage1;

            string resultMessage = "";

            if (failedSubjects.Count > 0)
            {
                resultMessage += "❌ KHÔNG XẾP ĐƯỢC:\n" + string.Join("\n", failedSubjects) + "\n\n";
            }

            if (warningMessages.Count > 0)
            {
                resultMessage += string.Join("\n", warningMessages.Take(10));
                if (warningMessages.Count > 10) resultMessage += $"\n... và {warningMessages.Count - 10} thông báo khác";
            }

            if (string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show("✅ Xếp lịch thành công cho tất cả môn!",
                                "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultMessage, "Kết quả xếp lịch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =============================================================
        // PHẦN 3: XỬ LÝ GIAO DIỆN
        // =============================================================
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            ClearInputs();

            if (dgv == dgvdangki)
            {
                txtsosv.Text = row.Cells[0].Value?.ToString();
                txtmamonthi.Text = row.Cells[2].Value?.ToString();
                txttenmonthi.Text = row.Cells[3].Value?.ToString();

                string maMon = txtmamonthi.Text;
                if (!string.IsNullOrEmpty(maMon))
                {
                    if (globalRoomResult.ContainsKey(maMon)) txtphongthi.Text = globalRoomResult[maMon];
                    if (globalTimeResult.ContainsKey(maMon))
                    {
                        string timeFull = globalTimeResult[maMon];
                        txtcathi.Text = timeFull;
                        string[] parts = timeFull.Split(new string[] { " - " }, StringSplitOptions.None);
                        if (parts.Length > 0 && DateTime.TryParse(parts[0], out DateTime d)) dtngaysinh.Value = d;
                    }
                    if (globalGraph.ContainsKey(maMon))
                        txtsosv.Text = globalGraph[maMon].Students.Count.ToString();
                }
            }
            else if (dgv == dgvcathi)
            {
                if (DateTime.TryParse(row.Cells[0].Value?.ToString(), out DateTime date)) dtngaysinh.Value = date;
                txtcathi.Text = row.Cells[1].Value?.ToString();
                txtphongthi.Text = row.Cells[2].Value?.ToString();
            }
            else if (dgv == dgvlichthi)
            {
                txtmamonthi.Text = row.Cells[0].Value?.ToString();
                txttenmonthi.Text = row.Cells[1].Value?.ToString();
                if (DateTime.TryParse(row.Cells[2].Value?.ToString(), out DateTime date)) dtngaysinh.Value = date;
                txtcathi.Text = row.Cells[3].Value?.ToString();
                txtphongthi.Text = row.Cells[4].Value?.ToString();
                txtsosv.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void ClearInputs()
        {
            txtsosv.Clear(); 
            txtmamonthi.Clear(); txttenmonthi.Clear();
            txtcathi.Clear(); txtphongthi.Clear();
            dtngaysinh.Value = DateTime.Now;
        }

        // ← XUẤT EXCEL CHI TIẾT - HIỆN ĐÚNG PHÒNG CHO TỪNG SINH VIÊN
        private void BtnExportStudentDetail_Click(object sender, EventArgs e)
        {
            if (globalGraph.Count == 0) { MessageBox.Show("Hãy xếp lịch trước!"); return; }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "LichThi_ChiTiet_SV.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("LichSV");
                            ws.Cell(1, 1).Value = "Mã SV"; ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 2).Value = "Tên SV"; ws.Cell(1, 2).Style.Font.Bold = true;
                            ws.Cell(1, 3).Value = "Môn Thi"; ws.Cell(1, 3).Style.Font.Bold = true;
                            ws.Cell(1, 4).Value = "Thời Gian"; ws.Cell(1, 4).Style.Font.Bold = true;
                            ws.Cell(1, 5).Value = "Phòng Thi"; ws.Cell(1, 5).Style.Font.Bold = true;

                            int r = 2;
                            foreach (var sub in globalGraph.Values)
                            {
                                if (globalRoomResult.ContainsKey(sub.ID))
                                {
                                    string t = globalTimeResult[sub.ID];

                                    foreach (var st in sub.Students)
                                    {
                                        ws.Cell(r, 1).Value = st;
                                        ws.Cell(r, 2).Value = sub.StudentNames[st];
                                        ws.Cell(r, 3).Value = sub.Name;
                                        ws.Cell(r, 4).Value = t;

                                        // ← HIỆN ĐÚNG PHÒNG CỤ THỂ CHO TỪNG SV
                                        string roomForThisStudent = sub.StudentRoomAssignment.ContainsKey(st)
                                            ? sub.StudentRoomAssignment[st]
                                            : globalRoomResult[sub.ID]; // Fallback nếu không có phân bổ

                                        ws.Cell(r, 5).Value = roomForThisStudent;
                                        r++;
                                    }
                                }
                            }
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
                }
            }
        }

        

        private void Btnlammoi_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show(
                "Xóa toàn bộ dữ liệu để làm mới?\n\nHành động này không thể hoàn tác!",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (check == DialogResult.Yes)
            {
                dgvdangki.Rows.Clear();
                dgvcathi.Rows.Clear();
                dgvlichthi.Rows.Clear();
                globalGraph.Clear();
                globalRoomResult.Clear();
                globalTimeResult.Clear();
                ClearInputs();
                MessageBox.Show("Đã làm mới hệ thống!", "Thông báo");
            }
        }

        private void Btnthoat_Click(object sender, EventArgs e) { Application.Exit(); }

        private DataGridView GetCurrentDGV()
        {
            if (tbctroldulieu.SelectedTab == tabPage2) return dgvdangki;
            if (tbctroldulieu.SelectedTab == tabPage3) return dgvcathi;
            return null;
        }

        private void btnlammoi_Click_1(object sender, EventArgs e) { }
        private void btnxlt_Click_1(object sender, EventArgs e) { }
        private void txtphongthi_TextChanged(object sender, EventArgs e) { }
        private void txtcathi_TextChanged(object sender, EventArgs e) { }
        private void txtsosv_TextChanged(object sender, EventArgs e) { }
        private void txtmamonthi_TextChanged(object sender, EventArgs e) { }
        private void txttenmonthi_TextChanged(object sender, EventArgs e) { }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {

        }
        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có đang chọn dòng nào bên bảng Kết quả không
            if (dgvlichthi.CurrentRow == null || dgvlichthi.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một dòng môn học trong bảng Kết Quả Xếp Lịch trước!", "Thông báo");
                return;
            }

            // 2. Lấy thông tin từ dòng đang chọn
            string maMon = dgvlichthi.CurrentRow.Cells[0].Value?.ToString(); // Cột 0 là Mã Môn
            string tenMon = dgvlichthi.CurrentRow.Cells[1].Value?.ToString();
            string thoigian = dgvlichthi.CurrentRow.Cells[2].Value + " - " + dgvlichthi.CurrentRow.Cells[3].Value; // Ngày - Ca
            string phong = dgvlichthi.CurrentRow.Cells[4].Value?.ToString();

            // 3. Lấy danh sách sinh viên từ biến toàn cục globalGraph
            if (!string.IsNullOrEmpty(maMon) && globalGraph.ContainsKey(maMon))
            {
                // Lấy danh sách tên SV của môn đó
                Dictionary<string, string> danhSachSV = globalGraph[maMon].StudentNames;

                // 4. Khởi tạo Form Chi Tiết và  truyền dữ liệu sang
                FormChiTiet frm = new FormChiTiet();

                // Gọi hàm mình vừa viết bên kia
                frm.HienThiDanhSach(maMon, tenMon, phong, thoigian, globalGraph[maMon].StudentNames);

                // Hiện Form lên (ShowDialog để bắt buộc xem xong mới được quay lại form chính)
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu sinh viên cho môn này (Có thể bạn chưa xếp lịch).", "Lỗi");
            }
        }
    }
}