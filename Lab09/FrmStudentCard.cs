using System.Drawing.Drawing2D;

namespace StudentCardPrinter
{
    public partial class FrmStudentCard : Form
    {
        public FrmStudentCard()
        {
            InitializeComponent();
            InitializeData();
            RegisterEvents();
        }

        private void InitializeData()
        {
            cboClass.Items.AddRange(new object[] { "K49.CNTT.A", "K50.CNTT.A", "K51.CNTT.A" });
            cboFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học" });
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboClass.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.SetValue(pnlCardPreview, true);
        }

        private void RegisterEvents()
        {
            btnChoosePhoto.Click += btnChoosePhoto_Click;
            btnPreviewPrint.Click += btnPreviewPrint_Click;
            btnPrint.Click += btnPrint_Click;
            btnClear.Click += btnClear_Click;
            btnExit.Click += (s, e) => Close();
            pnlCardPreview.Paint += pnlCardPreview_Paint;
            printDocument1.PrintPage += printDocument1_PrintPage;
            txtStudentId.TextChanged += InputChanged;
            txtFullName.TextChanged += InputChanged;
            txtCourse.TextChanged += InputChanged;
            cboClass.SelectedIndexChanged += InputChanged;
            cboClass.TextChanged += InputChanged;
            cboFaculty.SelectedIndexChanged += InputChanged;
            cboFaculty.TextChanged += InputChanged;
            cboGender.SelectedIndexChanged += InputChanged;
            dtpBirthDate.ValueChanged += InputChanged;
        }

        private void btnChoosePhoto_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn ảnh sinh viên";
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using Image temp = Image.FromFile(dlg.FileName);
                Image copy = new Bitmap(temp);
                picAvatar.Image?.Dispose();
                picAvatar.Image = copy;
                pnlCardPreview.Invalidate();
            }
            catch
            {
                MessageBox.Show("File được chọn không phải ảnh hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private StudentCardInfo GetStudentInfo()
        {
            return new StudentCardInfo
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                ClassName = cboClass.Text,
                Faculty = cboFaculty.Text,
                Course = txtCourse.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = cboGender.Text,
                Photo = picAvatar.Image
            };
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                txtStudentId.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtFullName.Focus();
                return false;
            }
            if (picAvatar.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh sinh viên.");
                return false;
            }
            return true;
        }

        private void InputChanged(object? sender, EventArgs e)
        {
            pnlCardPreview.Invalidate();
        }

        private void pnlCardPreview_Paint(object? sender, PaintEventArgs e)
        {
            DrawStudentCard(e.Graphics, new Rectangle(20, 20, 520, 320), GetStudentInfo());
        }

        private void DrawStudentCard(Graphics g, Rectangle card, StudentCardInfo s)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using Font schoolFont = new Font("Arial", 10, FontStyle.Bold);
            using Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            using Font labelFont = new Font("Arial", 10, FontStyle.Bold);
            using Font normalFont = new Font("Arial", 10, FontStyle.Regular);
            using Pen borderPen = new Pen(Color.Navy, 2);
            using SolidBrush blueBrush = new SolidBrush(Color.Navy);
            using SolidBrush bgBrush = new SolidBrush(Color.FromArgb(238, 247, 247));

            g.FillRectangle(bgBrush, card);
            g.DrawRectangle(borderPen, card);
            int x = card.Left;
            int y = card.Top;
            g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", schoolFont, blueBrush, x + 20, y + 15);
            g.DrawString("THẺ SINH VIÊN", titleFont, blueBrush, x + 20, y + 45);

            Rectangle photoBox = new Rectangle(x + 25, y + 90, 115, 150);
            g.FillRectangle(Brushes.White, photoBox);
            g.DrawRectangle(Pens.Gray, photoBox);
            if (s.Photo != null) DrawImageZoom(g, s.Photo, photoBox);
            else g.DrawString("Ảnh", normalFont, Brushes.Gray, photoBox.Left + 35, photoBox.Top + 65);

            int ix = x + 165;
            int iy = y + 90;
            DrawInfoLine(g, "MSSV:", s.StudentId, labelFont, normalFont, ix, iy);
            DrawInfoLine(g, "Họ tên:", s.FullName, labelFont, normalFont, ix, iy + 30);
            DrawInfoLine(g, "Lớp:", s.ClassName, labelFont, normalFont, ix, iy + 60);
            DrawInfoLine(g, "Khoa:", s.Faculty, labelFont, normalFont, ix, iy + 90);
            DrawInfoLine(g, "Khóa:", s.Course, labelFont, normalFont, ix, iy + 120);
            DrawInfoLine(g, "Ngày sinh:", s.BirthDate.ToString("dd/MM/yyyy"), labelFont, normalFont, ix, iy + 150);
            DrawInfoLine(g, "Giới tính:", s.Gender, labelFont, normalFont, ix, iy + 180);
        }

        private void DrawInfoLine(Graphics g, string label, string value, Font labelFont, Font normalFont, int x, int y)
        {
            g.DrawString(label, labelFont, Brushes.Black, x, y);
            g.DrawString(value, normalFont, Brushes.Black, x + 90, y);
        }

        private void DrawImageZoom(Graphics g, Image image, Rectangle box)
        {
            float ratio = Math.Min((float)box.Width / image.Width, (float)box.Height / image.Height);
            int w = (int)(image.Width * ratio);
            int h = (int)(image.Height * ratio);
            int x = box.Left + (box.Width - w) / 2;
            int y = box.Top + (box.Height - h) / 2;
            g.DrawImage(image, new Rectangle(x, y, w, h));
        }

        private void btnPreviewPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Width = 900;
            printPreviewDialog1.Height = 700;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
        }

        private void printDocument1_PrintPage(object? sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle card = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, 520, 320);
            DrawStudentCard(e.Graphics!, card, GetStudentInfo());
            e.HasMorePages = false;
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtCourse.Clear();
            cboClass.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            dtpBirthDate.Value = DateTime.Today;
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            pnlCardPreview.Invalidate();
            txtStudentId.Focus();
        }
    }
}
