namespace ShopManagerMini.Forms
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new MenuStrip();
            this.mnuSystem = new ToolStripMenuItem();
            this.mnuLogout = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.mnuExit = new ToolStripMenuItem();
            this.mnuCategory = new ToolStripMenuItem();
            this.mnuProduct = new ToolStripMenuItem();
            this.mnuCustomer = new ToolStripMenuItem();
            this.mnuHelp = new ToolStripMenuItem();
            this.mnuAbout = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.lblStatusUser = new ToolStripStatusLabel();
            this.lblStatusRole = new ToolStripStatusLabel();
            this.lblStatusTime = new ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.mnuSystem,
                this.mnuCategory,
                this.mnuHelp
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(900, 24);

            // mnuSystem - Hệ thống
            this.mnuSystem.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuLogout,
                this.toolStripSeparator1,
                this.mnuExit
            });
            this.mnuSystem.Text = "Hệ thống";

            // mnuLogout
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);

            // mnuExit
            this.mnuExit.Text = "Thoát";
            this.mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);

            // mnuCategory - Danh mục
            this.mnuCategory.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuProduct,
                this.mnuCustomer
            });
            this.mnuCategory.Text = "Danh mục";

            // mnuProduct
            this.mnuProduct.Text = "Quản lý sản phẩm";
            this.mnuProduct.Click += new System.EventHandler(this.mnuProduct_Click);

            // mnuCustomer
            this.mnuCustomer.Text = "Quản lý khách hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);

            // mnuHelp - Trợ giúp
            this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuAbout
            });
            this.mnuHelp.Text = "Trợ giúp";

            // mnuAbout
            this.mnuAbout.Text = "Giới thiệu";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.lblStatusUser,
                this.lblStatusRole,
                this.lblStatusTime
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 528);
            this.statusStrip.Size = new System.Drawing.Size(900, 22);

            // lblStatusUser
            this.lblStatusUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            this.lblStatusUser.Text = "Người dùng: ";
            this.lblStatusUser.AutoSize = false;
            this.lblStatusUser.Size = new System.Drawing.Size(250, 17);
            this.lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblStatusRole
            this.lblStatusRole.BorderSides = ToolStripStatusLabelBorderSides.Right;
            this.lblStatusRole.Text = "Vai trò: ";
            this.lblStatusRole.AutoSize = false;
            this.lblStatusRole.Size = new System.Drawing.Size(200, 17);
            this.lblStatusRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblStatusTime
            this.lblStatusTime.Text = "Thời gian: ";
            this.lblStatusTime.Spring = true;
            this.lblStatusTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // timerClock
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ShopManagerMini - Quản lý cửa hàng mini";
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosing += new FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuCategory;
        private ToolStripMenuItem mnuProduct;
        private ToolStripMenuItem mnuCustomer;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuAbout;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusUser;
        private ToolStripStatusLabel lblStatusRole;
        private ToolStripStatusLabel lblStatusTime;
        private System.Windows.Forms.Timer timerClock;
    }
}
