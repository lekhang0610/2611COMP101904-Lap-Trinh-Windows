namespace ShopManagerMini.Forms
{
    partial class FrmCustomer
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
            this.grpInfo = new GroupBox();
            this.lblCustomerId = new Label();
            this.txtCustomerId = new TextBox();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblCustomerType = new Label();
            this.cboCustomerType = new ComboBox();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.grpSearch = new GroupBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.dgvCustomers = new DataGridView();
            this.grpInfo.SuspendLayout();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // grpInfo
            this.grpInfo.Controls.Add(this.lblCustomerId);
            this.grpInfo.Controls.Add(this.txtCustomerId);
            this.grpInfo.Controls.Add(this.lblFullName);
            this.grpInfo.Controls.Add(this.txtFullName);
            this.grpInfo.Controls.Add(this.lblPhone);
            this.grpInfo.Controls.Add(this.txtPhone);
            this.grpInfo.Controls.Add(this.lblCustomerType);
            this.grpInfo.Controls.Add(this.cboCustomerType);
            this.grpInfo.Controls.Add(this.btnAdd);
            this.grpInfo.Controls.Add(this.btnEdit);
            this.grpInfo.Controls.Add(this.btnDelete);
            this.grpInfo.Controls.Add(this.btnRefresh);
            this.grpInfo.Location = new System.Drawing.Point(12, 12);
            this.grpInfo.Size = new System.Drawing.Size(760, 150);
            this.grpInfo.Text = "Thông tin khách hàng";
            this.grpInfo.Dock = DockStyle.Top;

            // lblCustomerId
            this.lblCustomerId.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerId.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerId.Text = "Mã khách hàng:";

            // txtCustomerId
            this.txtCustomerId.Location = new System.Drawing.Point(130, 28);
            this.txtCustomerId.Size = new System.Drawing.Size(180, 23);

            // lblFullName
            this.lblFullName.Location = new System.Drawing.Point(20, 65);
            this.lblFullName.Size = new System.Drawing.Size(100, 23);
            this.lblFullName.Text = "Họ tên:";

            // txtFullName
            this.txtFullName.Location = new System.Drawing.Point(130, 63);
            this.txtFullName.Size = new System.Drawing.Size(180, 23);

            // lblPhone
            this.lblPhone.Location = new System.Drawing.Point(350, 30);
            this.lblPhone.Size = new System.Drawing.Size(100, 23);
            this.lblPhone.Text = "Số điện thoại:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(460, 28);
            this.txtPhone.Size = new System.Drawing.Size(180, 23);

            // lblCustomerType
            this.lblCustomerType.Location = new System.Drawing.Point(350, 65);
            this.lblCustomerType.Size = new System.Drawing.Size(100, 23);
            this.lblCustomerType.Text = "Loại khách hàng:";

            // cboCustomerType
            this.cboCustomerType.Location = new System.Drawing.Point(460, 63);
            this.cboCustomerType.Size = new System.Drawing.Size(180, 23);
            this.cboCustomerType.DropDownStyle = ComboBoxStyle.DropDown;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(130, 105);
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(230, 105);
            this.btnEdit.Size = new System.Drawing.Size(90, 32);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(330, 105);
            this.btnDelete.Size = new System.Drawing.Size(90, 32);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(430, 105);
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // grpSearch
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(12, 168);
            this.grpSearch.Size = new System.Drawing.Size(760, 55);
            this.grpSearch.Text = "Tìm kiếm";
            this.grpSearch.Dock = DockStyle.Top;

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 22);
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.PlaceholderText = "Nhập mã KH, họ tên hoặc số điện thoại để tìm...";

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.Orange;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(430, 19);
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 230);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(760, 300);
            this.dgvCustomers.Dock = DockStyle.Fill;
            this.dgvCustomers.CellClick += new DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

            // FrmCustomer
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpInfo);
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblCustomerType;
        private ComboBox cboCustomerType;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private GroupBox grpSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvCustomers;
    }
}
