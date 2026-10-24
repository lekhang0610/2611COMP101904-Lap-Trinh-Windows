using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form quản lý sản phẩm - CRUD trong bộ nhớ với DataGridView
    /// </summary>
    public partial class FrmProduct : Form
    {
        // Danh sách sản phẩm lưu trong bộ nhớ
        private BindingList<Product> _products = new BindingList<Product>();

        public FrmProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form - Khởi tạo dữ liệu mẫu và binding DataGridView
        /// </summary>
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu mẫu
            _products.Add(new Product("SP001", "Mì tôm Hảo Hảo", "Thực phẩm", 4500, 100));
            _products.Add(new Product("SP002", "Nước suối Aquafina", "Nước uống", 5000, 200));
            _products.Add(new Product("SP003", "Bánh mì sandwich", "Thực phẩm", 15000, 50));
            _products.Add(new Product("SP004", "Sữa Vinamilk 1L", "Sữa", 32000, 80));
            _products.Add(new Product("SP005", "Bút bi Thiên Long", "Văn phòng phẩm", 3500, 150));

            // Binding DataGridView
            dgvProducts.DataSource = _products;

            // Đặt tên cột tiếng Việt
            dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
            dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            dgvProducts.Columns["Category"].HeaderText = "Loại SP";
            dgvProducts.Columns["UnitPrice"].HeaderText = "Đơn giá";
            dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";
            dgvProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";

            // Load danh sách loại sản phẩm
            cboCategory.Items.AddRange(new string[] { "Thực phẩm", "Nước uống", "Sữa", "Văn phòng phẩm", "Khác" });
        }

        /// <summary>
        /// Xử lý khi chọn dòng trên DataGridView - Hiển thị thông tin lên các TextBox
        /// </summary>
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _products.Count)
            {
                Product p = _products[e.RowIndex];
                txtProductId.Text = p.ProductId;
                txtProductName.Text = p.ProductName;
                cboCategory.Text = p.Category;
                txtUnitPrice.Text = p.UnitPrice.ToString();
                txtQuantity.Text = p.Quantity.ToString();

                // Không cho sửa mã sản phẩm khi đang chọn
                txtProductId.ReadOnly = true;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào hợp lệ
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboCategory.Text))
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Nút Thêm sản phẩm mới
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string id = txtProductId.Text.Trim();

            // Kiểm tra trùng mã
            if (_products.Any(p => p.ProductId == id))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại! Vui lòng nhập mã khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductId.Focus();
                return;
            }

            Product newProduct = new Product(
                id,
                txtProductName.Text.Trim(),
                cboCategory.Text.Trim(),
                decimal.Parse(txtUnitPrice.Text),
                int.Parse(txtQuantity.Text)
            );

            _products.Add(newProduct);
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
        }

        /// <summary>
        /// Nút Sửa sản phẩm đang chọn
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            int index = dgvProducts.CurrentRow.Index;
            if (index >= 0 && index < _products.Count)
            {
                _products[index].ProductName = txtProductName.Text.Trim();
                _products[index].Category = cboCategory.Text.Trim();
                _products[index].UnitPrice = decimal.Parse(txtUnitPrice.Text);
                _products[index].Quantity = int.Parse(txtQuantity.Text);

                // Refresh DataGridView
                _products.ResetBindings();
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Nút Xóa sản phẩm đang chọn
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = dgvProducts.CurrentRow.Index;
                if (index >= 0 && index < _products.Count)
                {
                    _products.RemoveAt(index);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
            }
        }

        /// <summary>
        /// Nút Tìm kiếm sản phẩm theo tên
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống, hiển thị lại tất cả
                dgvProducts.DataSource = _products;
                return;
            }

            var results = _products.Where(p =>
                p.ProductName.ToLower().Contains(keyword) ||
                p.ProductId.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword)
            ).ToList();

            dgvProducts.DataSource = new BindingList<Product>(results);
        }

        /// <summary>
        /// Nút Làm mới - Xóa các TextBox và hiển thị lại toàn bộ danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtSearch.Clear();
            dgvProducts.DataSource = _products;
            txtProductId.ReadOnly = false;
        }

        /// <summary>
        /// Xóa nội dung các TextBox nhập liệu
        /// </summary>
        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = "";
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtProductId.ReadOnly = false;
            txtProductId.Focus();
        }
    }
}
