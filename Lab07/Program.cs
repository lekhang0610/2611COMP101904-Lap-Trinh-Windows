using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy ứng dụng ShopManagerMini
        /// Hiển thị FrmLogin trước, nếu đăng nhập thành công thì mở FrmMain
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Hiển thị form đăng nhập dưới dạng dialog
            FrmLogin frmLogin = new FrmLogin();

            if (frmLogin.ShowDialog() == DialogResult.OK && frmLogin.LoggedInUser != null)
            {
                // Đăng nhập thành công - Truyền thông tin user sang FrmMain
                Application.Run(new FrmMain(frmLogin.LoggedInUser));
            }
            else
            {
                // Người dùng hủy đăng nhập - Thoát ứng dụng
                Application.Exit();
            }
        }
    }
}
