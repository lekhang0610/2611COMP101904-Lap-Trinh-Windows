namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        private System.ComponentModel.IContainer components = null!;
        private Label lblLop = null!;
        private Label lblMon = null!;
        private ComboBox cboLop = null!;
        private ComboBox cboMonHoc = null!;
        private Button btnTaiDanhSach = null!;
        private Button btnLuuTatCa = null!;
        private DataGridView dgvKetQua = null!;
        private StatusStrip statusStrip1 = null!;
        private ToolStripStatusLabel lblTrangThai = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLop = new Label();
            lblMon = new Label();
            cboLop = new ComboBox();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            btnLuuTatCa = new Button();
            dgvKetQua = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            lblLop.AutoSize = true;
            lblLop.Location = new Point(15, 18);
            lblLop.Text = "Lớp:";

            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(60, 14);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(220, 23);

            lblMon.AutoSize = true;
            lblMon.Location = new Point(300, 18);
            lblMon.Text = "Môn học:";

            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.Location = new Point(365, 14);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(220, 23);

            btnTaiDanhSach.Location = new Point(600, 12);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(120, 27);
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;

            btnLuuTatCa.Location = new Point(730, 12);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(120, 27);
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.Click += btnLuuTatCa_Click;

            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.Location = new Point(15, 50);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.Size = new Size(835, 360);
            dgvKetQua.DataError += dgvKetQua_DataError;

            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Text = "Sẵn sàng";
            statusStrip1.Items.Add(lblTrangThai);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 445);
            Controls.AddRange(new Control[] { lblLop, cboLop, lblMon, cboMonHoc, btnTaiDanhSach, btnLuuTatCa, dgvKetQua, statusStrip1 });
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập điểm theo lớp";
            Load += FrmNhapDiemTheoLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
