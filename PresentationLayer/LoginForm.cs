<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
﻿using BusinessLayer;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class LoginFrom : Form
    {
        public LoginFrom()
        {
            InitializeComponent();
            this.KeyPreview = true; // 🔑 Quan trọng
        }

        private void btDangNhap_Click(object sender, System.EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var service = new UserService(); // hoặc inject từ constructor nếu dùng DI
            var user = service.Authenticate(username, password);
            if (user != null)
            {
                // Ẩn form hiện tại
                this.Hide();
                // Mở MainForm
                var mainForm = new MainForm(user);
                mainForm.FormClosed += (s, args) => this.Close(); // Đảm bảo đóng app khi MainForm đóng
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, System.EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = ckbHienMatKhau.Checked;
        }

        private void LoginFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btDangNhap.PerformClick(); // Gọi sự kiện click của nút Đăng Nhập
            }
<<<<<<< HEAD
=======
=======
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
﻿using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
<<<<<<< HEAD
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
        }
    }
}
