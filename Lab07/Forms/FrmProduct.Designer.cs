namespace ShopManagerMini.Forms
{
    partial class FrmProduct
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
            this.lblProductId = new Label();
            this.txtProductId = new TextBox();
            this.lblProductName = new Label();
            this.txtProductName = new TextBox();
            this.lblCategory = new Label();
            this.cboCategory = new ComboBox();
            this.lblUnitPrice = new Label();
            this.txtUnitPrice = new TextBox();
            this.lblQuantity = new Label();
            this.txtQuantity = new TextBox();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.grpSearch = new GroupBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.dgvProducts = new DataGridView();
            this.grpInfo.SuspendLayout();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            // grpInfo
            this.grpInfo.Controls.Add(this.lblProductId);
            this.grpInfo.Controls.Add(this.txtProductId);
            this.grpInfo.Controls.Add(this.lblProductName);
            this.grpInfo.Controls.Add(this.txtProductName);
            this.grpInfo.Controls.Add(this.lblCategory);
            this.grpInfo.Controls.Add(this.cboCategory);
            this.grpInfo.Controls.Add(this.lblUnitPrice);
            this.grpInfo.Controls.Add(this.txtUnitPrice);
            this.grpInfo.Controls.Add(this.lblQuantity);
            this.grpInfo.Controls.Add(this.txtQuantity);
            this.grpInfo.Controls.Add(this.btnAdd);
            this.grpInfo.Controls.Add(this.btnEdit);
            this.grpInfo.Controls.Add(this.btnDelete);
            this.grpInfo.Controls.Add(this.btnRefresh);
            this.grpInfo.Location = new System.Drawing.Point(12, 12);
            this.grpInfo.Size = new System.Drawing.Size(760, 180);
            this.grpInfo.Text = "Thông tin sản phẩm";
            this.grpInfo.Dock = DockStyle.Top;

            // lblProductId
            this.lblProductId.Location = new System.Drawing.Point(20, 30);
            this.lblProductId.Size = new System.Drawing.Size(100, 23);
            this.lblProductId.Text = "Mã sản phẩm:";

            // txtProductId
            this.txtProductId.Location = new System.Drawing.Point(130, 28);
            this.txtProductId.Size = new System.Drawing.Size(180, 23);

            // lblProductName
            this.lblProductName.Location = new System.Drawing.Point(20, 65);
            this.lblProductName.Size = new System.Drawing.Size(100, 23);
            this.lblProductName.Text = "Tên sản phẩm:";

            // txtProductName
            this.txtProductName.Location = new System.Drawing.Point(130, 63);
            this.txtProductName.Size = new System.Drawing.Size(180, 23);

            // lblCategory
            this.lblCategory.Location = new System.Drawing.Point(20, 100);
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.Text = "Loại sản phẩm:";

            // cboCategory
            this.cboCategory.Location = new System.Drawing.Point(130, 98);
            this.cboCategory.Size = new System.Drawing.Size(180, 23);
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDown;

            // lblUnitPrice
            this.lblUnitPrice.Location = new System.Drawing.Point(350, 30);
            this.lblUnitPrice.Size = new System.Drawing.Size(80, 23);
            this.lblUnitPrice.Text = "Đơn giá:";

            // txtUnitPrice
            this.txtUnitPrice.Location = new System.Drawing.Point(440, 28);
            this.txtUnitPrice.Size = new System.Drawing.Size(150, 23);

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(350, 65);
            this.lblQuantity.Size = new System.Drawing.Size(80, 23);
            this.lblQuantity.Text = "Số lượng:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(440, 63);
            this.txtQuantity.Size = new System.Drawing.Size(150, 23);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(130, 135);
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(230, 135);
            this.btnEdit.Size = new System.Drawing.Size(90, 32);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(330, 135);
            this.btnDelete.Size = new System.Drawing.Size(90, 32);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(430, 135);
            this.btnRefresh.Size = new System.Drawing.Size(90, 32);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // grpSearch
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(12, 198);
            this.grpSearch.Size = new System.Drawing.Size(760, 55);
            this.grpSearch.Text = "Tìm kiếm";
            this.grpSearch.Dock = DockStyle.Top;

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 22);
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.PlaceholderText = "Nhập mã SP, tên SP hoặc loại SP để tìm...";

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

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 260);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(760, 280);
            this.dgvProducts.Dock = DockStyle.Fill;
            this.dgvProducts.CellClick += new DataGridViewCellEventHandler(this.dgvProducts_CellClick);

            // FrmProduct
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpInfo);
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblUnitPrice;
        private TextBox txtUnitPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private GroupBox grpSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
    }
}
