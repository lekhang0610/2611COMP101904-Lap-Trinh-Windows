using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    public class FrmPaint : Form
    {
        private readonly DrawSurface canvas = new DrawSurface();
        private readonly ComboBox cboMode = new ComboBox();
        private readonly NumericUpDown nudWidth = new NumericUpDown();
        private readonly CheckBox chkFill = new CheckBox();
        private readonly Button btnColor = new Button();
        private readonly Button btnBack = new Button();
        private readonly Button btnUndo = new Button();
        private readonly Button btnClear = new Button();
        private readonly Button btnSave = new Button();
        private readonly Label lblStatus = new Label();

        private readonly List<DrawItem> items = new List<DrawItem>();
        private DrawItem current;
        private Color color = Color.Black;

        public FrmPaint()
        {
            Text = "COMP1019 - Simple Paint";
            Width = 1000;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
            BuildUi();
            RegisterEvents();
        }

        private void BuildUi()
        {
            Panel top = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.FromArgb(238, 247, 247) };

            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(Enum.GetNames(typeof(DrawMode)));
            cboMode.SelectedIndex = 0;
            cboMode.SetBounds(60, 12, 100, 24);

            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;
            nudWidth.SetBounds(225, 12, 55, 24);

            chkFill.Text = "Fill";
            chkFill.SetBounds(295, 13, 50, 24);

            btnColor.Text = "Color";
            btnColor.SetBounds(350, 10, 70, 28);
            btnBack.Text = "Background";
            btnBack.SetBounds(425, 10, 90, 28);
            btnUndo.Text = "Undo";
            btnUndo.SetBounds(520, 10, 70, 28);
            btnClear.Text = "Clear";
            btnClear.SetBounds(595, 10, 70, 28);
            btnSave.Text = "Save PNG";
            btnSave.SetBounds(670, 10, 85, 28);

            top.Controls.Add(new Label { Text = "Mode", Left = 15, Top = 16, AutoSize = true });
            top.Controls.Add(cboMode);
            top.Controls.Add(new Label { Text = "Width", Left = 180, Top = 16, AutoSize = true });
            top.Controls.AddRange(new Control[] { nudWidth, chkFill, btnColor, btnBack, btnUndo, btnClear, btnSave });

            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Height = 26;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;

            Controls.Add(canvas);
            Controls.Add(lblStatus);
            Controls.Add(top);
        }

        private void RegisterEvents()
        {
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;
            btnColor.Click += BtnColor_Click;
            btnBack.Click += BtnBack_Click;
            btnUndo.Click += (s, e) => Undo();
            btnClear.Click += BtnClear_Click;
            btnSave.Click += BtnSave_Click;
            KeyDown += FrmPaint_KeyDown;
        }

        private DrawMode CurrentMode
        {
            get { return (DrawMode)Enum.Parse(typeof(DrawMode), cboMode.SelectedItem.ToString()); }
        }

        private void Undo()
        {
            if (items.Count == 0) return;
            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
        }

        private void FrmPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.Handled = true;
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dlg = new ColorDialog();
            dlg.Color = color;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                btnColor.BackColor = color;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            using ColorDialog dlg = new ColorDialog();
            dlg.Color = canvas.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                canvas.BackColor = dlg.Color;
                canvas.Invalidate();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) return;
            DialogResult r = MessageBox.Show("Xóa toàn bộ vùng vẽ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                items.Clear();
                canvas.Invalidate();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG image|*.png";
            dlg.FileName = "paint.png";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                using Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
                using Graphics g = Graphics.FromImage(bmp);
                g.Clear(canvas.BackColor);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (DrawItem item in items) DrawOne(g, item);
                bmp.Save(dlg.FileName, ImageFormat.Png);
                lblStatus.Text = "Saved: " + dlg.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            current = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = color,
                Width = (float)nudWidth.Value,
                Fill = chkFill.Checked
            };
            if (current.Mode == DrawMode.Pen) current.Points.Add(e.Location);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}, Items = {items.Count}";
            if (current == null) return;
            current.End = e.Location;
            if (current.Mode == DrawMode.Pen) current.Points.Add(e.Location);
            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (current == null || e.Button != MouseButtons.Left) return;
            current.End = e.Location;
            items.Add(current);
            current = null;
            canvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (DrawItem item in items) DrawOne(e.Graphics, item);
            if (current != null) DrawOne(e.Graphics, current);
        }

        private void DrawOne(Graphics g, DrawItem item)
        {
            using Pen pen = new Pen(item.Color, item.Width);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            Rectangle rect = GetRect(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    DrawFree(g, pen, item.Points);
                    break;
                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;
                case DrawMode.Rectangle:
                    if (item.Fill)
                    {
                        using Brush b = new SolidBrush(item.Color);
                        g.FillRectangle(b, rect);
                    }
                    g.DrawRectangle(pen, rect);
                    break;
                case DrawMode.Ellipse:
                    if (item.Fill)
                    {
                        using Brush b = new SolidBrush(item.Color);
                        g.FillEllipse(b, rect);
                    }
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void DrawFree(Graphics g, Pen pen, List<Point> pts)
        {
            if (pts.Count == 0) return;
            if (pts.Count == 1)
            {
                g.DrawLine(pen, pts[0], pts[0]);
                return;
            }
            for (int i = 1; i < pts.Count; i++)
                g.DrawLine(pen, pts[i - 1], pts[i]);
        }

        private Rectangle GetRect(Point a, Point b)
        {
            return new Rectangle(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
        }
    }
}
