using System;
using System.Windows.Forms;

namespace LTDT
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            // Mẹo: Đặt thuộc tính này để ô password hiện dấu * thay vì chữ
            Password.PasswordChar = '*';
        }

        // Sự kiện khi nhấn nút Đăng Nhập
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string tk = Username.Text;
            string mk = Password.Text;

            // Kiểm tra tài khoản và mật khẩu
            if (tk == "admin" && mk == "123")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1. Ẩn form đăng nhập đi
                this.Hide();

                // 2. Khởi tạo và hiện Form1 (Form chính của bạn)
                Form1 mainForm = new Form1();

                // Xử lý sự kiện: Khi tắt Form1 thì tắt luôn cả chương trình (bao gồm formLogin đang ẩn)
                mainForm.Closed += (s, args) => this.Close();

                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Focus(); // Đưa con trỏ chuột về ô mật khẩu để nhập lại
            }
        }

        // Sự kiện khi nhấn nút Thoát
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Các hàm này nếu không dùng bạn có thể để trống
        private void Username_TextChanged(object sender, EventArgs e) { }
        private void Password_TextChanged(object sender, EventArgs e) { }
    }
}