using System;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThongTinCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            var loi = new StringBuilder();

            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
                loi.AppendLine("- Họ tên không được để trống.");

            string namSinhText = txtNamSinh.Text.Trim();
            int namSinh = 0;
            int namHienTai = DateTime.Now.Year;
            if (string.IsNullOrEmpty(namSinhText))
            {
                loi.AppendLine("- Năm sinh không được để trống.");
            }
            else if (!int.TryParse(namSinhText, out namSinh))
            {
                loi.AppendLine("- Năm sinh phải là số nguyên.");
            }
            else if (namSinh < 1900 || namSinh > namHienTai)
            {
                loi.AppendLine($"- Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}.");
            }

            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
                loi.AppendLine("- Email không được để trống.");

            if (!radNam.Checked && !radNu.Checked)
                loi.AppendLine("- Vui lòng chọn giới tính.");

            if (cboKhoa.SelectedIndex == -1)
                loi.AppendLine("- Vui lòng chọn khoa hoặc lớp.");

            if (loi.Length > 0)
            {
                MessageBox.Show(loi.ToString(), "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tuoi = namHienTai - namSinh;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            var ketQua = new StringBuilder();
            ketQua.AppendLine("THÔNG TIN SINH VIÊN");
            ketQua.AppendLine($"Họ tên: {hoTen}");
            ketQua.AppendLine($"Tuổi: {tuoi}");
            ketQua.AppendLine($"Email: {email}");
            ketQua.AppendLine($"Giới tính: {gioiTinh}");
            ketQua.AppendLine($"Khoa/Lớp: {cboKhoa.SelectedItem}");

            txtKetQua.Text = ketQua.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
            txtKetQua.Clear();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var xacNhan = MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
                Application.Exit();
        }
    }
}
