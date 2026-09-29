namespace CourseRegistrationApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTieuDe = new Label();
        grpHocVien = new GroupBox();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblSoDienThoai = new Label();
        txtSoDienThoai = new TextBox();
        lblNgaySinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        chkNhanEmail = new CheckBox();
        grpKhoaHoc = new GroupBox();
        lblKhoaHoc = new Label();
        cboKhoaHoc = new ComboBox();
        lblHinhThuc = new Label();
        radOnline = new RadioButton();
        radOffline = new RadioButton();
        lblSoThang = new Label();
        numSoThang = new NumericUpDown();
        lblTongTienText = new Label();
        lblTongTien = new Label();
        btnDangKy = new Button();
        btnLamMoi = new Button();
        btnThoat = new Button();
        grpHocVien.SuspendLayout();
        grpKhoaHoc.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
        SuspendLayout();

        lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTieuDe.Location = new Point(0, 10);
        lblTieuDe.Name = "lblTieuDe";
        lblTieuDe.Size = new Size(520, 30);
        lblTieuDe.Text = "ĐĂNG KÝ KHÓA HỌC";
        lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

        grpHocVien.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblSoDienThoai, txtSoDienThoai, lblNgaySinh, dtpNgaySinh, chkNhanEmail });
        grpHocVien.Location = new Point(12, 50);
        grpHocVien.Name = "grpHocVien";
        grpHocVien.Size = new Size(496, 190);
        grpHocVien.TabIndex = 0;
        grpHocVien.TabStop = false;
        grpHocVien.Text = "Thông tin học viên";

        lblHoTen.AutoSize = true;
        lblHoTen.Location = new Point(20, 33);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Text = "Họ tên:";

        txtHoTen.Location = new Point(140, 30);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(330, 27);
        txtHoTen.TabIndex = 0;

        lblSoDienThoai.AutoSize = true;
        lblSoDienThoai.Location = new Point(20, 73);
        lblSoDienThoai.Name = "lblSoDienThoai";
        lblSoDienThoai.Text = "Số điện thoại:";

        txtSoDienThoai.Location = new Point(140, 70);
        txtSoDienThoai.Name = "txtSoDienThoai";
        txtSoDienThoai.Size = new Size(330, 27);
        txtSoDienThoai.TabIndex = 1;

        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Location = new Point(20, 113);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Text = "Ngày sinh:";

        dtpNgaySinh.Format = DateTimePickerFormat.Short;
        dtpNgaySinh.Location = new Point(140, 110);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.Size = new Size(200, 27);
        dtpNgaySinh.TabIndex = 2;

        chkNhanEmail.AutoSize = true;
        chkNhanEmail.Location = new Point(140, 150);
        chkNhanEmail.Name = "chkNhanEmail";
        chkNhanEmail.TabIndex = 3;
        chkNhanEmail.Text = "Nhận email thông báo";
        chkNhanEmail.UseVisualStyleBackColor = true;

        grpKhoaHoc.Controls.AddRange(new Control[] { lblKhoaHoc, cboKhoaHoc, lblHinhThuc, radOnline, radOffline, lblSoThang, numSoThang, lblTongTienText, lblTongTien });
        grpKhoaHoc.Location = new Point(12, 250);
        grpKhoaHoc.Name = "grpKhoaHoc";
        grpKhoaHoc.Size = new Size(496, 190);
        grpKhoaHoc.TabIndex = 1;
        grpKhoaHoc.TabStop = false;
        grpKhoaHoc.Text = "Thông tin khóa học";

        lblKhoaHoc.AutoSize = true;
        lblKhoaHoc.Location = new Point(20, 33);
        lblKhoaHoc.Name = "lblKhoaHoc";
        lblKhoaHoc.Text = "Khóa học:";

        cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKhoaHoc.Location = new Point(140, 30);
        cboKhoaHoc.Name = "cboKhoaHoc";
        cboKhoaHoc.Size = new Size(330, 28);
        cboKhoaHoc.TabIndex = 0;
        cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;

        lblHinhThuc.AutoSize = true;
        lblHinhThuc.Location = new Point(20, 73);
        lblHinhThuc.Name = "lblHinhThuc";
        lblHinhThuc.Text = "Hình thức:";

        radOnline.AutoSize = true;
        radOnline.Location = new Point(140, 71);
        radOnline.Name = "radOnline";
        radOnline.TabIndex = 1;
        radOnline.Text = "Online";
        radOnline.UseVisualStyleBackColor = true;

        radOffline.AutoSize = true;
        radOffline.Location = new Point(250, 71);
        radOffline.Name = "radOffline";
        radOffline.TabIndex = 2;
        radOffline.Text = "Trực tiếp";
        radOffline.UseVisualStyleBackColor = true;

        lblSoThang.AutoSize = true;
        lblSoThang.Location = new Point(20, 113);
        lblSoThang.Name = "lblSoThang";
        lblSoThang.Text = "Số tháng:";

        numSoThang.Location = new Point(140, 110);
        numSoThang.Name = "numSoThang";
        numSoThang.Size = new Size(80, 27);
        numSoThang.TabIndex = 3;
        numSoThang.ValueChanged += numSoThang_ValueChanged;

        lblTongTienText.AutoSize = true;
        lblTongTienText.Location = new Point(20, 150);
        lblTongTienText.Name = "lblTongTienText";
        lblTongTienText.Text = "Tổng học phí:";

        lblTongTien.AutoSize = true;
        lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblTongTien.ForeColor = Color.Firebrick;
        lblTongTien.Location = new Point(140, 148);
        lblTongTien.Name = "lblTongTien";
        lblTongTien.Text = "0 VNĐ";

        btnDangKy.Location = new Point(140, 452);
        btnDangKy.Name = "btnDangKy";
        btnDangKy.Size = new Size(110, 34);
        btnDangKy.TabIndex = 2;
        btnDangKy.Text = "Đăng ký";
        btnDangKy.UseVisualStyleBackColor = true;
        btnDangKy.Click += btnDangKy_Click;

        btnLamMoi.Location = new Point(265, 452);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(110, 34);
        btnLamMoi.TabIndex = 3;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        btnThoat.Location = new Point(390, 452);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(110, 34);
        btnThoat.TabIndex = 4;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(520, 500);
        Controls.AddRange(new Control[] { lblTieuDe, grpHocVien, grpKhoaHoc, btnDangKy, btnLamMoi, btnThoat });
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ĐĂNG KÝ KHÓA HỌC";
        Load += Form1_Load;
        grpHocVien.ResumeLayout(false);
        grpHocVien.PerformLayout();
        grpKhoaHoc.ResumeLayout(false);
        grpKhoaHoc.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
        ResumeLayout(false);
    }

    private Label lblTieuDe;
    private GroupBox grpHocVien;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private Label lblSoDienThoai;
    private TextBox txtSoDienThoai;
    private Label lblNgaySinh;
    private DateTimePicker dtpNgaySinh;
    private CheckBox chkNhanEmail;
    private GroupBox grpKhoaHoc;
    private Label lblKhoaHoc;
    private ComboBox cboKhoaHoc;
    private Label lblHinhThuc;
    private RadioButton radOnline;
    private RadioButton radOffline;
    private Label lblSoThang;
    private NumericUpDown numSoThang;
    private Label lblTongTienText;
    private Label lblTongTien;
    private Button btnDangKy;
    private Button btnLamMoi;
    private Button btnThoat;
}
