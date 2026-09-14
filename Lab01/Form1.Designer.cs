namespace QuanLyThongTinCaNhan
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNamSinh;
        private TextBox txtNamSinh;
        private Label lblEmail;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtKetQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNamSinh = new Label();
            txtNamSinh = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            grpGioiTinh = new GroupBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtKetQua = new TextBox();
            grpGioiTinh.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(400, 30);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Text = "ỨNG DỤNG THÔNG TIN CÁ NHÂN";

            // lblHoTen
            lblHoTen.Location = new Point(20, 62);
            lblHoTen.Size = new Size(85, 23);
            lblHoTen.Text = "Họ tên:";

            // txtHoTen
            txtHoTen.Location = new Point(115, 59);
            txtHoTen.Size = new Size(295, 23);

            // lblNamSinh
            lblNamSinh.Location = new Point(20, 97);
            lblNamSinh.Size = new Size(85, 23);
            lblNamSinh.Text = "Năm sinh:";

            // txtNamSinh
            txtNamSinh.Location = new Point(115, 94);
            txtNamSinh.Size = new Size(295, 23);

            // lblEmail
            lblEmail.Location = new Point(20, 132);
            lblEmail.Size = new Size(85, 23);
            lblEmail.Text = "Email:";

            // txtEmail
            txtEmail.Location = new Point(115, 129);
            txtEmail.Size = new Size(295, 23);

            // grpGioiTinh
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Location = new Point(20, 167);
            grpGioiTinh.Size = new Size(390, 50);
            grpGioiTinh.Text = "Giới tính";

            // radNam
            radNam.Location = new Point(15, 20);
            radNam.Size = new Size(80, 23);
            radNam.Text = "Nam";

            // radNu
            radNu.Location = new Point(120, 20);
            radNu.Size = new Size(80, 23);
            radNu.Text = "Nữ";

            // lblKhoa
            lblKhoa.Location = new Point(20, 230);
            lblKhoa.Size = new Size(85, 23);
            lblKhoa.Text = "Khoa/Lớp:";

            // cboKhoa
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Location = new Point(115, 227);
            cboKhoa.Size = new Size(295, 23);
            cboKhoa.Items.AddRange(new object[] {
                "Công nghệ thông tin",
                "Công nghệ giáo dục",
                "Sư phạm tin học"
            });

            // btnHienThi
            btnHienThi.Location = new Point(20, 270);
            btnHienThi.Size = new Size(115, 35);
            btnHienThi.Text = "Hiển thị";
            btnHienThi.Click += btnHienThi_Click;

            // btnXoa
            btnXoa.Location = new Point(157, 270);
            btnXoa.Size = new Size(115, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // btnThoat
            btnThoat.Location = new Point(294, 270);
            btnThoat.Size = new Size(116, 35);
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;

            // txtKetQua
            txtKetQua.Location = new Point(20, 320);
            txtKetQua.Size = new Size(390, 160);
            txtKetQua.Multiline = true;
            txtKetQua.ReadOnly = true;
            txtKetQua.ScrollBars = ScrollBars.Vertical;
            txtKetQua.Font = new Font("Consolas", 10F);

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 500);
            Controls.Add(lblTitle);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(txtNamSinh);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(grpGioiTinh);
            Controls.Add(lblKhoa);
            Controls.Add(cboKhoa);
            Controls.Add(btnHienThi);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(txtKetQua);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông Tin Cá Nhân";
            grpGioiTinh.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
