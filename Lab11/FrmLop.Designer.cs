namespace COMP1019_Buoi11_Lab11
{
    partial class FrmLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvLop = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();

            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(20, 23);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Text = "Mã lớp:";

            txtMaLop.Location = new Point(100, 20);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(200, 27);
            txtMaLop.TabIndex = 0;

            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(330, 23);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Text = "Tên lớp:";

            txtTenLop.Location = new Point(410, 20);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(310, 27);
            txtTenLop.TabIndex = 1;

            btnThem.Location = new Point(20, 65);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 32);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(130, 65);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 32);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(240, 65);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 32);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(350, 65);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            txtTimKiem.Location = new Point(20, 115);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên lớp...";
            txtTimKiem.Size = new Size(300, 27);
            txtTimKiem.TabIndex = 6;

            btnTimKiem.Location = new Point(330, 113);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 32);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;

            dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.ReadOnly = true;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.MultiSelect = false;
            dgvLop.Location = new Point(20, 160);
            dgvLop.Name = "dgvLop";
            dgvLop.RowHeadersWidth = 51;
            dgvLop.Size = new Size(700, 300);
            dgvLop.TabIndex = 8;
            dgvLop.CellClick += dgvLop_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 481);
            Controls.AddRange(new Control[] { lblMaLop, txtMaLop, lblTenLop, txtTenLop, btnThem, btnSua,
                btnXoa, btnLamMoi, txtTimKiem, btnTimKiem, dgvLop });
            Name = "FrmLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học";
            Load += FrmLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaLop;
        private TextBox txtMaLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvLop;
    }
}
