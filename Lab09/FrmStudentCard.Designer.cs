using System.Drawing.Printing;

namespace StudentCardPrinter
{
    partial class FrmStudentCard
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label NewLabel(string text, int y)
        {
            return new Label { Text = text, Location = new Point(20, y + 4), AutoSize = true };
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtStudentId = new TextBox { Name = "txtStudentId", Location = new Point(110, 20), Size = new Size(220, 27) };
            txtFullName = new TextBox { Name = "txtFullName", Location = new Point(110, 56), Size = new Size(220, 27) };
            cboClass = new ComboBox { Name = "cboClass", Location = new Point(110, 92), Size = new Size(220, 28) };
            cboFaculty = new ComboBox { Name = "cboFaculty", Location = new Point(110, 128), Size = new Size(220, 28) };
            txtCourse = new TextBox { Name = "txtCourse", Location = new Point(110, 164), Size = new Size(220, 27) };
            dtpBirthDate = new DateTimePicker { Name = "dtpBirthDate", Location = new Point(110, 200), Size = new Size(220, 27), Format = DateTimePickerFormat.Short };
            cboGender = new ComboBox { Name = "cboGender", Location = new Point(110, 236), Size = new Size(220, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            picAvatar = new PictureBox { Name = "picAvatar", Location = new Point(110, 280), Size = new Size(100, 130), BorderStyle = BorderStyle.FixedSingle };
            btnChoosePhoto = new Button { Name = "btnChoosePhoto", Text = "Chọn ảnh", Location = new Point(220, 280), Size = new Size(110, 32) };
            btnPreviewPrint = new Button { Name = "btnPreviewPrint", Text = "Xem trước in", Location = new Point(20, 430), Size = new Size(150, 34) };
            btnPrint = new Button { Name = "btnPrint", Text = "In", Location = new Point(180, 430), Size = new Size(150, 34) };
            btnClear = new Button { Name = "btnClear", Text = "Làm mới", Location = new Point(20, 472), Size = new Size(150, 34) };
            btnExit = new Button { Name = "btnExit", Text = "Thoát", Location = new Point(180, 472), Size = new Size(150, 34) };
            pnlCardPreview = new Panel { Name = "pnlCardPreview", Location = new Point(360, 20), Size = new Size(560, 360), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();

            SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 530);
            Text = "In thẻ sinh viên";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Controls.AddRange(new Control[] {
                NewLabel("Mã SV:", 20), NewLabel("Họ tên:", 56), NewLabel("Lớp:", 92), NewLabel("Khoa:", 128),
                NewLabel("Khóa:", 164), NewLabel("Ngày sinh:", 200), NewLabel("Giới tính:", 236), NewLabel("Ảnh:", 280),
                txtStudentId, txtFullName, cboClass, cboFaculty, txtCourse, dtpBirthDate, cboGender,
                picAvatar, btnChoosePhoto, btnPreviewPrint, btnPrint, btnClear, btnExit, pnlCardPreview });
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtStudentId = null!;
        private TextBox txtFullName = null!;
        private ComboBox cboClass = null!;
        private ComboBox cboFaculty = null!;
        private TextBox txtCourse = null!;
        private DateTimePicker dtpBirthDate = null!;
        private ComboBox cboGender = null!;
        private PictureBox picAvatar = null!;
        private Panel pnlCardPreview = null!;
        private Button btnChoosePhoto = null!;
        private Button btnPreviewPrint = null!;
        private Button btnPrint = null!;
        private Button btnClear = null!;
        private Button btnExit = null!;
        private PrintDocument printDocument1 = null!;
        private PrintPreviewDialog printPreviewDialog1 = null!;
        private PrintDialog printDialog1 = null!;
    }
}
