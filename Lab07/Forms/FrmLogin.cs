using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form đăng nhập - Kiểm tra tài khoản mẫu và trả DialogResult.OK khi thành công
    /// </summary>
    public partial class FrmLogin : Form
    {
        // Danh sách tài khoản mẫu
        private List<User> _users = new List<User>
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user", "123", "Nhân viên bán hàng", "User")
        };

        /// <summary>
        /// Thông tin người dùng đã đăng nhập thành công
        /// </summary>
        public User? LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện nút Đăng nhập
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra bỏ trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tài khoản
            User? foundUser = _users.Find(u =>
                u.Username == username && u.Password == password);

            if (foundUser != null)
            {
                LoggedInUser = foundUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        /// <summary>
        /// Xử lý sự kiện nút Thoát
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Cho phép nhấn Enter để đăng nhập
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
            txtUsername.Focus();
        }
    }
}
