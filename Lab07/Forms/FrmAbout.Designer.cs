namespace ShopManagerMini.Forms
{
    partial class FrmAbout
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
            this.lblAppName = new Label();
            this.lblDescription = new Label();
            this.lblStudent = new Label();
            this.lblClass = new Label();
            this.lblVersion = new Label();
            this.btnClose = new Button();
            this.SuspendLayout();

            // lblAppName
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblAppName.Location = new System.Drawing.Point(30, 20);
            this.lblAppName.Size = new System.Drawing.Size(340, 40);
            this.lblAppName.Text = "ShopManagerMini";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblDescription
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(30, 70);
            this.lblDescription.Size = new System.Drawing.Size(340, 30);
            this.lblDescription.Text = "Ứng dụng quản lý cửa hàng mini";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblStudent
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblStudent.Location = new System.Drawing.Point(30, 120);
            this.lblStudent.Size = new System.Drawing.Size(340, 30);
            this.lblStudent.Text = "Sinh viên: [Họ và tên sinh viên]";
            this.lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblClass
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblClass.Location = new System.Drawing.Point(30, 155);
            this.lblClass.Size = new System.Drawing.Size(340, 30);
            this.lblClass.Text = "Lớp: [Mã lớp]";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblVersion
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(30, 195);
            this.lblVersion.Size = new System.Drawing.Size(340, 25);
            this.lblVersion.Text = "Phiên bản 1.0 - COMP1019 Buổi 7";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(140, 240);
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += (s, e) => this.Close();

            // FrmAbout
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Giới thiệu - ShopManagerMini";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Label lblAppName;
        private Label lblDescription;
        private Label lblStudent;
        private Label lblClass;
        private Label lblVersion;
        private Button btnClose;
    }
}
