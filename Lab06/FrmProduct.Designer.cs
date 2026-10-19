namespace ProductManager;

partial class FrmProduct
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        mnuFileExit = new ToolStripMenuItem { Name = "mnuFileExit", Text = "Thoát", ShortcutKeys = Keys.Control | Keys.Q };
        mnuFile = new ToolStripMenuItem { Name = "mnuFile", Text = "File" };
        mnuFile.DropDownItems.Add(mnuFileExit);
        mnuThem = new ToolStripMenuItem { Name = "mnuThem", Text = "Thêm", ShortcutKeys = Keys.Control | Keys.N };
        mnuSua = new ToolStripMenuItem { Name = "mnuSua", Text = "Sửa", ShortcutKeys = Keys.Control | Keys.E };
        mnuXoa = new ToolStripMenuItem { Name = "mnuXoa", Text = "Xóa", ShortcutKeys = Keys.Control | Keys.D };
        mnuLamMoi = new ToolStripMenuItem { Name = "mnuLamMoi", Text = "Làm mới", ShortcutKeys = Keys.F5 };
        mnuTimKiem = new ToolStripMenuItem { Name = "mnuTimKiem", Text = "Tìm kiếm", ShortcutKeys = Keys.Control | Keys.F };
        mnuQuanLy = new ToolStripMenuItem { Name = "mnuQuanLy", Text = "Quản lý" };
        mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuThem, mnuSua, mnuXoa, mnuLamMoi, mnuTimKiem });
        mnuAbout = new ToolStripMenuItem { Name = "mnuAbout", Text = "Giới thiệu" };
        mnuTroGiup = new ToolStripMenuItem { Name = "mnuTroGiup", Text = "Trợ giúp" };
        mnuTroGiup.DropDownItems.Add(mnuAbout);
        menuStrip1 = new MenuStrip { Name = "menuStrip1" };
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuTroGiup });

        tsbThem = new ToolStripButton { Name = "tsbThem", Text = "Thêm", DisplayStyle = ToolStripItemDisplayStyle.Text };
        tsbSua = new ToolStripButton { Name = "tsbSua", Text = "Sửa", DisplayStyle = ToolStripItemDisplayStyle.Text };
        tsbXoa = new ToolStripButton { Name = "tsbXoa", Text = "Xóa", DisplayStyle = ToolStripItemDisplayStyle.Text };
        tsbLamMoi = new ToolStripButton { Name = "tsbLamMoi", Text = "Làm mới", DisplayStyle = ToolStripItemDisplayStyle.Text };
        tsbTimKiem = new ToolStripButton { Name = "tsbTimKiem", Text = "Tìm kiếm", DisplayStyle = ToolStripItemDisplayStyle.Text };
        toolStrip1 = new ToolStrip { Name = "toolStrip1" };
        toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, new ToolStripSeparator(), tsbLamMoi, tsbTimKiem });

        lblStatus = new ToolStripStatusLabel { Name = "lblStatus", Text = "Sẵn sàng" };
        statusStrip1 = new StatusStrip { Name = "statusStrip1" };
        statusStrip1.Items.Add(lblStatus);

        txtMaSP = new TextBox { Name = "txtMaSP", Left = 110, Top = 30, Width = 220 };
        txtTenSP = new TextBox { Name = "txtTenSP", Left = 110, Top = 65, Width = 220 };
        cboLoaiSP = new ComboBox { Name = "cboLoaiSP", Left = 110, Top = 100, Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
        numDonGia = new NumericUpDown { Name = "numDonGia", Left = 110, Top = 135, Width = 220, Maximum = 1000000000, Increment = 1000, ThousandsSeparator = true };
        numSoLuong = new NumericUpDown { Name = "numSoLuong", Left = 110, Top = 170, Width = 220, Maximum = 1000000 };
        dtpNgayNhap = new DateTimePicker { Name = "dtpNgayNhap", Left = 110, Top = 205, Width = 220, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        chkConKinhDoanh = new CheckBox { Name = "chkConKinhDoanh", Left = 110, Top = 240, AutoSize = true, Text = "Còn kinh doanh", Checked = true };
        btnChonAnh = new Button { Name = "btnChonAnh", Left = 12, Top = 275, Width = 90, Height = 30, Text = "Chọn ảnh" };
        picSanPham = new PictureBox { Name = "picSanPham", Left = 110, Top = 275, Width = 220, Height = 150, BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
        btnThem = new Button { Name = "btnThem", Left = 12, Top = 445, Width = 100, Height = 34, Text = "Thêm" };
        btnSua = new Button { Name = "btnSua", Left = 122, Top = 445, Width = 100, Height = 34, Text = "Sửa" };
        btnXoa = new Button { Name = "btnXoa", Left = 232, Top = 445, Width = 100, Height = 34, Text = "Xóa" };

        grpThongTin = new GroupBox { Name = "grpThongTin", Text = "Thông tin sản phẩm", Dock = DockStyle.Left, Width = 350 };
        grpThongTin.Controls.AddRange(new Control[]
        {
            new Label { Text = "Mã SP", Left = 12, Top = 33, AutoSize = true },
            new Label { Text = "Tên SP", Left = 12, Top = 68, AutoSize = true },
            new Label { Text = "Loại SP", Left = 12, Top = 103, AutoSize = true },
            new Label { Text = "Đơn giá", Left = 12, Top = 138, AutoSize = true },
            new Label { Text = "Số lượng", Left = 12, Top = 173, AutoSize = true },
            new Label { Text = "Ngày nhập", Left = 12, Top = 208, AutoSize = true },
            txtMaSP, txtTenSP, cboLoaiSP, numDonGia, numSoLuong, dtpNgayNhap, chkConKinhDoanh,
            btnChonAnh, picSanPham, btnThem, btnSua, btnXoa
        });

        lblTim = new Label { Text = "Tìm (mã/tên)", Left = 8, Top = 12, AutoSize = true };
        txtTimKiem = new TextBox { Name = "txtTimKiem", Left = 100, Top = 8, Width = 240 };
        btnTimKiem = new Button { Name = "btnTimKiem", Left = 350, Top = 6, Width = 90, Height = 28, Text = "Tìm kiếm" };
        btnLamMoi = new Button { Name = "btnLamMoi", Left = 450, Top = 6, Width = 90, Height = 28, Text = "Làm mới" };
        pnlSearch = new Panel { Name = "pnlSearch", Dock = DockStyle.Top, Height = 42 };
        pnlSearch.Controls.AddRange(new Control[] { lblTim, txtTimKiem, btnTimKiem, btnLamMoi });

        cmsSua = new ToolStripMenuItem { Name = "cmsSua", Text = "Sửa" };
        cmsXoa = new ToolStripMenuItem { Name = "cmsXoa", Text = "Xóa" };
        cmsChiTiet = new ToolStripMenuItem { Name = "cmsChiTiet", Text = "Xem chi tiết" };
        cmsGrid = new ContextMenuStrip(components) { Name = "cmsGrid" };
        cmsGrid.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsChiTiet });

        dgvProducts = new DataGridView { Name = "dgvProducts", Dock = DockStyle.Fill, ContextMenuStrip = cmsGrid, BackgroundColor = SystemColors.Window };

        pnlRight = new Panel { Name = "pnlRight", Dock = DockStyle.Fill };
        pnlRight.Controls.Add(dgvProducts);
        pnlRight.Controls.Add(pnlSearch);

        errorProvider1 = new ErrorProvider(components) { ContainerControl = this };

        SuspendLayout();
        ClientSize = new Size(1100, 620);
        MinimumSize = new Size(900, 560);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý sản phẩm";
        Name = "FrmProduct";
        KeyPreview = true;
        MainMenuStrip = menuStrip1;
        Controls.Add(pnlRight);
        Controls.Add(grpThongTin);
        Controls.Add(statusStrip1);
        Controls.Add(toolStrip1);
        Controls.Add(menuStrip1);

        Load += FrmProduct_Load;
        btnThem.Click += btnThem_Click;
        btnSua.Click += btnSua_Click;
        btnXoa.Click += btnXoa_Click;
        btnTimKiem.Click += btnTimKiem_Click;
        btnLamMoi.Click += btnLamMoi_Click;
        btnChonAnh.Click += btnChonAnh_Click;
        txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        dgvProducts.CellClick += dgvProducts_CellClick;
        dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
        dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
        dgvProducts.KeyDown += dgvProducts_KeyDown;
        ResumeLayout(false);
        PerformLayout();
    }

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuFile, mnuFileExit, mnuQuanLy, mnuThem, mnuSua, mnuXoa, mnuLamMoi, mnuTimKiem, mnuTroGiup, mnuAbout;
    private ToolStrip toolStrip1;
    private ToolStripButton tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbTimKiem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
    private GroupBox grpThongTin;
    private TextBox txtMaSP, txtTenSP, txtTimKiem;
    private ComboBox cboLoaiSP;
    private NumericUpDown numDonGia, numSoLuong;
    private DateTimePicker dtpNgayNhap;
    private CheckBox chkConKinhDoanh;
    private PictureBox picSanPham;
    private Button btnChonAnh, btnThem, btnSua, btnXoa, btnTimKiem, btnLamMoi;
    private Panel pnlRight, pnlSearch;
    private Label lblTim;
    private DataGridView dgvProducts;
    private ContextMenuStrip cmsGrid;
    private ToolStripMenuItem cmsSua, cmsXoa, cmsChiTiet;
    private ErrorProvider errorProvider1;
}
