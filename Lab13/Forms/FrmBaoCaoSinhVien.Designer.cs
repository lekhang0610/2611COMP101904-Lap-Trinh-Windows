namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            dgvBaoCao = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblThongKe = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            //
            // lblLop
            //
            lblLop.AutoSize = true;
            lblLop.Location = new Point(20, 20);
            lblLop.Name = "lblLop";
            lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(20, 43);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(180, 23);
            //
            // lblKetQua
            //
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(220, 20);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Text = "Kết quả:";
            //
            // cboKetQua
            //
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.Location = new Point(220, 43);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(140, 23);
            //
            // lblTuKhoa
            //
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(380, 20);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Text = "Từ khóa (mã SV hoặc họ tên):";
            //
            // txtTuKhoa
            //
            txtTuKhoa.Location = new Point(380, 43);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.Size = new Size(220, 23);
            //
            // btnXemBaoCao
            //
            btnXemBaoCao.Location = new Point(20, 82);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(130, 32);
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            //
            // btnThongKe
            //
            btnThongKe.Location = new Point(160, 82);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(130, 32);
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            //
            // btnXuatFile
            //
            btnXuatFile.Location = new Point(300, 82);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(130, 32);
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = true;
            btnXuatFile.Click += btnXuatFile_Click;
            //
            // dgvBaoCao
            //
            dgvBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Location = new Point(20, 130);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(840, 340);
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblThongKe });
            statusStrip1.Name = "statusStrip1";
            //
            // lblThongKe
            //
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Text = "Sẵn sàng";
            //
            // FrmBaoCaoSinhVien
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 520);
            Controls.Add(lblLop);
            Controls.Add(cboLop);
            Controls.Add(lblKetQua);
            Controls.Add(cboKetQua);
            Controls.Add(lblTuKhoa);
            Controls.Add(txtTuKhoa);
            Controls.Add(btnXemBaoCao);
            Controls.Add(btnThongKe);
            Controls.Add(btnXuatFile);
            Controls.Add(dgvBaoCao);
            Controls.Add(statusStrip1);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo danh sách sinh viên theo lớp";
            Load += FrmBaoCaoSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private DataGridView dgvBaoCao;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblThongKe;
    }
}
