using System;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form chính MDI Parent - Có MenuStrip, StatusStrip, hiển thị tên người dùng và vai trò
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Thông tin người dùng đã đăng nhập
        /// </summary>
        public User CurrentUser { get; set; }

        public FrmMain()
        {
            InitializeComponent();
            CurrentUser = new User();
        }

        /// <summary>
        /// Constructor nhận thông tin người dùng từ FrmLogin
        /// </summary>
        public FrmMain(User user) : this()
        {
            CurrentUser = user;
        }

        /// <summary>
        /// Load form - Cập nhật StatusStrip với thông tin người dùng
        /// </summary>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng trên StatusStrip
            lblStatusUser.Text = $"Người dùng: {CurrentUser.FullName}";
            lblStatusRole.Text = $"Vai trò: {CurrentUser.Role}";
            lblStatusTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            // Cập nhật đồng hồ mỗi giây
            timerClock.Start();
        }

        /// <summary>
        /// Cập nhật thời gian trên StatusStrip
        /// </summary>
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblStatusTime.Text = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        /// <summary>
        /// Mở Form con MDI - Kiểm tra không mở trùng Form cùng loại
        /// </summary>
        private void OpenChildForm<T>() where T : Form, new()
        {
            // Kiểm tra xem Form cùng loại đã mở chưa
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    // Nếu đã mở, kích hoạt Form cũ
                    child.Activate();
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            // Tạo Form mới và mở dưới dạng MDI Child
            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        // ==================== Menu Hệ thống ====================

        /// <summary>
        /// Menu Đăng xuất - Quay lại màn hình đăng nhập
        /// </summary>
        private void mnuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                timerClock.Stop();
                this.Hide();

                FrmLogin frmLogin = new FrmLogin();
                if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.LoggedInUser != null)
                {
                    CurrentUser = frmLogin.LoggedInUser;
                    lblStatusUser.Text = $"Người dùng: {CurrentUser.FullName}";
                    lblStatusRole.Text = $"Vai trò: {CurrentUser.Role}";
                    timerClock.Start();

                    // Đóng tất cả Form con
                    foreach (Form child in this.MdiChildren)
                    {
                        child.Close();
                    }

                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Menu Thoát - Hỏi xác nhận trước khi thoát
        /// </summary>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==================== Menu Danh mục ====================

        /// <summary>
        /// Menu Quản lý sản phẩm
        /// </summary>
        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmProduct>();
        }

        /// <summary>
        /// Menu Quản lý khách hàng
        /// </summary>
        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmCustomer>();
        }

        // ==================== Menu Trợ giúp ====================

        /// <summary>
        /// Menu Giới thiệu
        /// </summary>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmAbout>();
        }

        /// <summary>
        /// Xử lý sự kiện đóng form - Hỏi xác nhận thoát
        /// </summary>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
