using System.Globalization;

namespace CourseRegistrationApp;

public partial class Form1 : Form
{
    private readonly Dictionary<string, int> khoaHoc = new()
    {
        ["C# WinForms cơ bản"] = 800000,
        ["SQL Server cơ bản"] = 700000,
        ["Web Frontend cơ bản"] = 750000,
        ["Lập trình Python cơ bản"] = 650000
    };

    private readonly CultureInfo vn = new("vi-VN");

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cboKhoaHoc.Items.AddRange(khoaHoc.Keys.ToArray());
        cboKhoaHoc.SelectedIndex = 0;
        radOnline.Checked = true;
        numSoThang.Minimum = 1;
        numSoThang.Maximum = 12;
        numSoThang.Value = 1;
        CapNhatTongTien();
    }

    private int TinhTongTien()
    {
        if (cboKhoaHoc.SelectedIndex < 0) return 0;
        return khoaHoc[cboKhoaHoc.Text] * (int)numSoThang.Value;
    }

    private string DinhDangTien(int tien) => tien.ToString("N0", vn) + " VNĐ";

    private void CapNhatTongTien()
    {
        lblTongTien.Text = DinhDangTien(TinhTongTien());
    }

    private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        CapNhatTongTien();
    }

    private void numSoThang_ValueChanged(object sender, EventArgs e)
    {
        CapNhatTongTien();
    }

    private void btnDangKy_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return;
        }

        if (cboKhoaHoc.SelectedIndex < 0)
        {
            MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboKhoaHoc.Focus();
            return;
        }

        string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
        string email = chkNhanEmail.Checked ? "Có" : "Không";

        string phieu =
            $"Họ tên: {txtHoTen.Text.Trim()}\n" +
            $"Số điện thoại: {txtSoDienThoai.Text.Trim()}\n" +
            $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}\n" +
            $"Khóa học: {cboKhoaHoc.Text}\n" +
            $"Hình thức học: {hinhThuc}\n" +
            $"Số tháng: {numSoThang.Value}\n" +
            $"Tổng tiền: {DinhDangTien(TinhTongTien())}\n" +
            $"Nhận email thông báo: {email}";

        MessageBox.Show(phieu, "PHIẾU ĐĂNG KÝ KHÓA HỌC", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        dtpNgaySinh.Value = DateTime.Now;
        chkNhanEmail.Checked = false;
        cboKhoaHoc.SelectedIndex = 0;
        radOnline.Checked = true;
        numSoThang.Value = 1;
        txtHoTen.Focus();
    }

    private void btnThoat_Click(object sender, EventArgs e)
    {
        var kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (kq == DialogResult.Yes) Close();
    }
}
