using System.ComponentModel;

namespace ProductManager;

public partial class FrmProduct : Form
{
    private readonly BindingList<Product> products = new();
    private readonly BindingSource productSource = new();
    private string imagePath = string.Empty;

    public FrmProduct()
    {
        InitializeComponent();
        WireActions();
    }

    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(new object[] { "Điện tử", "Văn phòng", "Gia dụng", "Thời trang" });
        cboLoaiSP.SelectedIndex = 0;
        AddSample("SP01", "Chuột không dây", "Điện tử", 150000, 20, true);
        AddSample("SP02", "Bút bi", "Văn phòng", 5000, 100, true);
        AddSample("SP03", "Nồi cơm điện", "Gia dụng", 850000, 8, true);
        AddSample("SP04", "Áo thun", "Thời trang", 120000, 35, false);
        SetupGrid();
        productSource.DataSource = products;
        dgvProducts.DataSource = productSource;
        UpdateStatus("Sẵn sàng");
    }

    private void WireActions()
    {
        tsbThem.Click += (s, e) => btnThem.PerformClick();
        tsbSua.Click += (s, e) => btnSua.PerformClick();
        tsbXoa.Click += (s, e) => btnXoa.PerformClick();
        tsbLamMoi.Click += (s, e) => btnLamMoi.PerformClick();
        tsbTimKiem.Click += (s, e) =>
        {
            if (txtTimKiem.Text.Trim().Length == 0) txtTimKiem.Focus();
            else btnTimKiem.PerformClick();
        };
        mnuThem.Click += (s, e) => btnThem.PerformClick();
        mnuSua.Click += (s, e) => btnSua.PerformClick();
        mnuXoa.Click += (s, e) => btnXoa.PerformClick();
        mnuLamMoi.Click += (s, e) => btnLamMoi.PerformClick();
        mnuTimKiem.Click += (s, e) => txtTimKiem.Focus();
        mnuFileExit.Click += (s, e) => Close();
        mnuAbout.Click += (s, e) => MessageBox.Show("ProductManager\nCOMP1019 - Lab 05", "Trợ giúp",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        cmsSua.Click += (s, e) => btnSua.PerformClick();
        cmsXoa.Click += (s, e) => btnXoa.PerformClick();
        cmsChiTiet.Click += (s, e) => ShowDetail();
    }

    private void AddSample(string ma, string ten, string loai, decimal gia, int sl, bool kd)
    {
        products.Add(new Product
        {
            MaSP = ma, TenSP = ten, LoaiSP = loai, DonGia = gia,
            SoLuong = sl, NgayNhap = DateTime.Today, ConKinhDoanh = kd
        });
    }

    private void SetupGrid()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AddColumn("MaSP", "Mã SP");
        AddColumn("TenSP", "Tên sản phẩm");
        AddColumn("LoaiSP", "Loại");
        AddColumn("DonGia", "Đơn giá", "N0");
        AddColumn("SoLuong", "Số lượng");
        AddColumn("NgayNhap", "Ngày nhập", "dd/MM/yyyy");
        dgvProducts.Columns.Add(new DataGridViewCheckBoxColumn
        {
            Name = "colConKinhDoanh", DataPropertyName = "ConKinhDoanh", HeaderText = "Còn KD"
        });
        AddColumn("ThanhTien", "Thành tiền", "N0");
    }

    private void AddColumn(string prop, string header, string format = "")
    {
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "col" + prop, DataPropertyName = prop, HeaderText = header,
            DefaultCellStyle = { Format = format }
        });
    }

    private bool ValidateInput(bool isEdit = false)
    {
        errorProvider1.Clear();
        bool ok = true;
        string ma = txtMaSP.Text.Trim();
        if (ma.Length == 0)
        {
            errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
            ok = false;
        }
        else if (!isEdit && products.Any(p => p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
        {
            errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
            ok = false;
        }
        if (string.IsNullOrWhiteSpace(txtTenSP.Text))
        {
            errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
            ok = false;
        }
        if (cboLoaiSP.SelectedIndex < 0)
        {
            errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
            ok = false;
        }
        if (numDonGia.Value <= 0)
        {
            errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
            ok = false;
        }
        if (numSoLuong.Value < 0)
        {
            errorProvider1.SetError(numSoLuong, "Số lượng không được âm");
            ok = false;
        }
        if (dtpNgayNhap.Value.Date > DateTime.Today)
        {
            errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn hôm nay");
            ok = false;
        }
        if (!ok)
            MessageBox.Show("Dữ liệu chưa hợp lệ, vui lòng kiểm tra các ô báo lỗi.", "Lỗi nhập liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return ok;
    }

    private Product? GetSelectedProduct()
    {
        if (productSource.Current is not Product p)
        {
            MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        return p;
    }

    private void LoadProductToForm(Product p)
    {
        errorProvider1.Clear();
        txtMaSP.Text = p.MaSP;
        txtMaSP.ReadOnly = true;
        txtTenSP.Text = p.TenSP;
        cboLoaiSP.Text = p.LoaiSP;
        numDonGia.Value = p.DonGia;
        numSoLuong.Value = p.SoLuong;
        dtpNgayNhap.Value = p.NgayNhap;
        chkConKinhDoanh.Checked = p.ConKinhDoanh;
        imagePath = p.DuongDanAnh;
        ShowImage(imagePath);
    }

    private void ClearInput()
    {
        txtMaSP.Clear();
        txtMaSP.ReadOnly = false;
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 0;
        numSoLuong.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
        imagePath = string.Empty;
        ShowImage(imagePath);
        errorProvider1.Clear();
        txtMaSP.Focus();
    }

    private void UpdateStatus(string message)
    {
        decimal total = products.Sum(p => p.ThanhTien);
        lblStatus.Text = $"{message} | Số sản phẩm: {products.Count} | Tổng giá trị tồn kho: {total:N0} đ";
    }

    private void ShowImage(string path)
    {
        picSanPham.Image?.Dispose();
        picSanPham.Image = null;
        if (path.Length == 0 || !File.Exists(path)) return;
        try
        {
            using var img = Image.FromFile(path);
            picSanPham.Image = new Bitmap(img);
        }
        catch
        {
            MessageBox.Show("Không đọc được file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ApplyFilter()
    {
        string k = txtTimKiem.Text.Trim();
        if (k.Length == 0)
        {
            productSource.DataSource = products;
            return;
        }
        var list = products.Where(p => p.MaSP.Contains(k, StringComparison.OrdinalIgnoreCase)
                                    || p.TenSP.Contains(k, StringComparison.OrdinalIgnoreCase)).ToList();
        productSource.DataSource = new BindingList<Product>(list);
    }

    private void ShowDetail()
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;
        MessageBox.Show(
            $"Mã: {p.MaSP}\nTên: {p.TenSP}\nLoại: {p.LoaiSP}\nĐơn giá: {p.DonGia:N0}\nSố lượng: {p.SoLuong}\n" +
            $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\nTrạng thái: {(p.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
            $"Thành tiền: {p.ThanhTien:N0}",
            "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        products.Add(new Product
        {
            MaSP = txtMaSP.Text.Trim(),
            TenSP = txtTenSP.Text.Trim(),
            LoaiSP = cboLoaiSP.Text,
            DonGia = numDonGia.Value,
            SoLuong = (int)numSoLuong.Value,
            NgayNhap = dtpNgayNhap.Value.Date,
            ConKinhDoanh = chkConKinhDoanh.Checked,
            DuongDanAnh = imagePath
        });
        ApplyFilter();
        ClearInput();
        UpdateStatus("Đã thêm sản phẩm mới");
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;
        if (txtMaSP.Text.Trim() != p.MaSP)
        {
            LoadProductToForm(p);
            UpdateStatus("Chỉnh sửa thông tin rồi nhấn Sửa để lưu");
            return;
        }
        if (!ValidateInput(true)) return;
        p.TenSP = txtTenSP.Text.Trim();
        p.LoaiSP = cboLoaiSP.Text;
        p.DonGia = numDonGia.Value;
        p.SoLuong = (int)numSoLuong.Value;
        p.NgayNhap = dtpNgayNhap.Value.Date;
        p.ConKinhDoanh = chkConKinhDoanh.Checked;
        p.DuongDanAnh = imagePath;
        productSource.ResetBindings(false);
        ClearInput();
        UpdateStatus("Đã cập nhật sản phẩm");
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;
        var rs = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {p.TenSP}?", "Xác nhận xóa",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (rs != DialogResult.Yes) return;
        products.Remove(p);
        ApplyFilter();
        ClearInput();
        UpdateStatus("Đã xóa sản phẩm");
    }

    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        ApplyFilter();
        UpdateStatus($"Tìm thấy {productSource.Count} sản phẩm");
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        txtTimKiem.Clear();
        ApplyFilter();
        ClearInput();
        UpdateStatus("Đã làm mới dữ liệu");
    }

    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Chọn ảnh sản phẩm",
            Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp"
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        imagePath = dlg.FileName;
        ShowImage(imagePath);
        UpdateStatus("Đã chọn ảnh sản phẩm");
    }

    private void txtTimKiem_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        btnTimKiem.PerformClick();
    }

    private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (productSource.Current is Product p) LoadProductToForm(p);
    }

    private void dgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) ShowDetail();
    }

    private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];
    }

    private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete) return;
        e.Handled = true;
        btnXoa.PerformClick();
    }
}
