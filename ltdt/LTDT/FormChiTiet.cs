using ClosedXML.Excel; // Đừng quên dòng này
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LTDT
{
    public partial class FormChiTiet : Form
    {
        // --- CÁC BIẾN LƯU TRỮ DỮ LIỆU ĐỂ DÙNG KHI XUẤT FILE ---
        private string _maMon;
        private string _tenMon;
        private string _phong;
        private string _thoiGian;
        private Dictionary<string, string> _listSV;

        public FormChiTiet()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvChiTiet.ColumnCount = 3;
            dgvChiTiet.Columns[0].Name = "STT";
            dgvChiTiet.Columns[1].Name = "Mã Sinh Viên";
            dgvChiTiet.Columns[2].Name = "Tên Sinh Viên";
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Cập nhật hàm này để nhận thêm maMon (để đặt tên file Excel)
        public void HienThiDanhSach(string maMon, string tenMon, string phong, string thoigian, Dictionary<string, string> listSV)
        {
            // 1. Lưu dữ liệu vào biến toàn cục của Form này
            _maMon = maMon;
            _tenMon = tenMon;
            _phong = phong;
            _thoiGian = thoigian;
            _listSV = listSV;

            // 2. Hiển thị lên giao diện
            lblTieuDe.Text = $"MÔN: {tenMon.ToUpper()} | PHÒNG: {phong} | CA: {thoigian}";

            dgvChiTiet.Rows.Clear();
            int stt = 1;
            foreach (var sv in listSV)
            {
                dgvChiTiet.Rows.Add(stt, sv.Key, sv.Value);
                stt++;
            }
        }

        // --- SỰ KIỆN NÚT XUẤT FILE (Nằm trong FormChiTiet) ---
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (_listSV == null || _listSV.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"DS_Thi_{_maMon}_{_phong}.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("DanhSachPhongThi");

                            // --- TIÊU ĐỀ ---
                            var titleRange = worksheet.Range("A1:E1");
                            titleRange.Merge().Value = "DANH SÁCH SINH VIÊN DỰ THI";
                            titleRange.Style.Font.Bold = true;
                            titleRange.Style.Font.FontSize = 16;
                            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            worksheet.Cell(2, 2).Value = $"Môn Thi: {_tenMon} ({_maMon})";
                            worksheet.Cell(3, 2).Value = $"Phòng Thi: {_phong}";
                            worksheet.Cell(3, 4).Value = $"Thời Gian: {_thoiGian}";
                            worksheet.Range("B2:B3").Style.Font.Bold = true;

                            // --- HEADER BẢNG ---
                            int headerRow = 5;
                            string[] headers = { "STT", "Mã Sinh Viên", "Họ Và Tên", "Chữ Ký", "Ghi Chú" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = worksheet.Cell(headerRow, i + 1);
                                cell.Value = headers[i];
                                cell.Style.Font.Bold = true;
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            // --- DỮ LIỆU ---
                            int currentRow = headerRow + 1;
                            int stt = 1;
                            foreach (var sv in _listSV)
                            {
                                worksheet.Cell(currentRow, 1).Value = stt++;
                                worksheet.Cell(currentRow, 2).Value = sv.Key;   // Mã SV
                                worksheet.Cell(currentRow, 3).Value = sv.Value; // Tên SV

                                // Kẻ khung
                                worksheet.Range(currentRow, 1, currentRow, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                currentRow++;
                            }

                            worksheet.Columns().AdjustToContents();
                            worksheet.Column(4).Width = 20; // Cột Chữ ký
                            worksheet.Column(5).Width = 20; // Cột Ghi chú

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
                    }
                }
            }
        }

        private void FormChiTiet_Load(object sender, EventArgs e)
        {

        }
    }
}