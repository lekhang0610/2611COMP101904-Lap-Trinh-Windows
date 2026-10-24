using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form quản lý khách hàng - Thêm, sửa, xóa, tìm kiếm trong bộ nhớ
    /// </summary>
    public partial class FrmCustomer : Form
    {
        // Danh sách khách hàng lưu trong bộ nhớ
        private BindingList<Customer> _customers = new BindingList<Customer>();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form - Khởi tạo dữ liệu mẫu và binding DataGridView
        /// </summary>
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu mẫu
            _customers.Add(new Customer("KH001", "Nguyễn Văn An", "0901234567", "Thường"));
            _customers.Add(new Customer("KH002", "Trần Thị Bình", "0912345678", "VIP"));
            _customers.Add(new Customer("KH003", "Lê Văn Cường", "0923456789", "Thường"));

            // Binding DataGridView
            dgvCustomers.DataSource = _customers;

            // Đặt tên cột tiếng Việt
            dgvCustomers.Columns["CustomerId"].HeaderText = "Mã KH";
            dgvCustomers.Columns["FullName"].HeaderText = "Họ tên";
            dgvCustomers.Columns["Phone"].HeaderText = "Số điện thoại";
            dgvCustomers.Columns["CustomerType"].HeaderText = "Loại KH";

            // Load danh sách loại khách hàng
            cboCustomerType.Items.AddRange(new string[] { "Thường", "VIP", "Doanh nghiệp" });
        }

        /// <summary>
        /// Xử lý khi chọn dòng trên DataGridView
        /// </summary>
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                Customer c = _customers[e.RowIndex];
                txtCustomerId.Text = c.CustomerId;
                txtFullName.Text = c.FullName;
                txtPhone.Text = c.Phone;
                cboCustomerType.Text = c.CustomerType;

                txtCustomerId.ReadOnly = true;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào hợp lệ
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboCustomerType.Text))
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCustomerType.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Nút Thêm khách hàng
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string id = txtCustomerId.Text.Trim();

            // Kiểm tra trùng mã
            if (_customers.Any(c => c.CustomerId == id))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerId.Focus();
                return;
            }

            Customer newCustomer = new Customer(
                id,
                txtFullName.Text.Trim(),
                txtPhone.Text.Trim(),
                cboCustomerType.Text.Trim()
            );

            _customers.Add(newCustomer);
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
        }

        /// <summary>
        /// Nút Sửa khách hàng
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            int index = dgvCustomers.CurrentRow.Index;
            if (index >= 0 && index < _customers.Count)
            {
                _customers[index].FullName = txtFullName.Text.Trim();
                _customers[index].Phone = txtPhone.Text.Trim();
                _customers[index].CustomerType = cboCustomerType.Text.Trim();

                _customers.ResetBindings();
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Nút Xóa khách hàng
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = dgvCustomers.CurrentRow.Index;
                if (index >= 0 && index < _customers.Count)
                {
                    _customers.RemoveAt(index);
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
            }
        }

        /// <summary>
        /// Nút Tìm kiếm khách hàng
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvCustomers.DataSource = _customers;
                return;
            }

            var results = _customers.Where(c =>
                c.FullName.ToLower().Contains(keyword) ||
                c.CustomerId.ToLower().Contains(keyword) ||
                c.Phone.Contains(keyword)
            ).ToList();

            dgvCustomers.DataSource = new BindingList<Customer>(results);
        }

        /// <summary>
        /// Nút Làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtSearch.Clear();
            dgvCustomers.DataSource = _customers;
            txtCustomerId.ReadOnly = false;
        }

        /// <summary>
        /// Xóa nội dung các TextBox nhập liệu
        /// </summary>
        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cboCustomerType.SelectedIndex = -1;
            cboCustomerType.Text = "";
            txtCustomerId.ReadOnly = false;
            txtCustomerId.Focus();
        }
    }
}
