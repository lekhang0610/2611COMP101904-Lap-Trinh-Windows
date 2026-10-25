using System.Text;
using StudentReportDemo.Models;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        // Nguồn dữ liệu gốc
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            XemBaoCao();
        }

        // ===================== 1. DỮ LIỆU MẪU =====================
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",    MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",  MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",      MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        // ===================== 2. LOAD COMBOBOX =====================
        private void LoadComboBox()
        {
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .ToList();

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;
        }

        // ===================== 3. XEM BÁO CÁO (LỌC) =====================
        private void XemBaoCao()
        {
            if (cboLop.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            var query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

            if (ketQua == "Đạt")
                query = query.Where(sv => sv.Diem >= 5);
            else if (ketQua == "Không đạt")
                query = query.Where(sv => sv.Diem < 5);

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // Danh sách sinh viên đã lọc, sắp xếp giảm dần theo điểm
            var dsLoc = query
                .OrderByDescending(sv => sv.Diem)
                .ThenBy(sv => sv.HoTen)
                .ToList();

            var baoCao = dsLoc
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            DatTieuDeCot();
            CapNhatThongKe(dsLoc);

            if (baoCao.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện đã chọn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===================== 4. CẬP NHẬT THỐNG KÊ (STATUS STRIP) =====================
        private void CapNhatThongKe(List<SinhVien> dsDangHienThi)
        {
            int tongSo = dsDangHienThi.Count;
            int soDat = dsDangHienThi.Count(sv => sv.Diem >= 5);
            int soKhongDat = dsDangHienThi.Count(sv => sv.Diem < 5);
            double diemTB = tongSo > 0 ? dsDangHienThi.Average(sv => sv.Diem) : 0; // tránh Average trên danh sách rỗng

            lblThongKe.Text = $"Tổng: {tongSo} sinh viên | Đạt: {soDat} | Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}";
        }

        // ===================== 5. THỐNG KÊ THEO LỚP =====================
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            dgvBaoCao.DataSource = thongKe;
            DatTieuDeCot();

            lblThongKe.Text = $"Thống kê theo lớp: {thongKe.Count} lớp | " +
                              $"Tổng: {thongKe.Sum(x => x.SoLuong)} sinh viên";
        }

        // ===================== 6. XUẤT FILE =====================
        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                // CSV dùng dấu phẩy, TXT dùng tab
                string phanCach = Path.GetExtension(sfd.FileName).ToLower() == ".txt" ? "\t" : ",";
                bool laCsv = phanCach == ",";

                var sb = new StringBuilder();

                // Dòng tiêu đề
                var tieuDe = dgvBaoCao.Columns.Cast<DataGridViewColumn>()
                    .Select(c => laCsv ? ThoatCsv(c.HeaderText) : c.HeaderText);
                sb.AppendLine(string.Join(phanCach, tieuDe));

                // Các dòng dữ liệu
                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cacO = row.Cells.Cast<DataGridViewCell>()
                        .Select(c =>
                        {
                            string giaTri = c.Value?.ToString() ?? "";
                            return laCsv ? ThoatCsv(giaTri) : giaTri;
                        });
                    sb.AppendLine(string.Join(phanCach, cacO));
                }

                // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show("Xuất file thành công:\n" + sfd.FileName, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không ghi được file (file đang được mở?): " + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Không có quyền ghi vào vị trí này: " + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bọc giá trị trong dấu nháy kép nếu chứa dấu phẩy / nháy kép / xuống dòng
        private static string ThoatCsv(string giaTri)
        {
            if (giaTri.Contains(',') || giaTri.Contains('"') || giaTri.Contains('\n'))
                return "\"" + giaTri.Replace("\"", "\"\"") + "\"";
            return giaTri;
        }

        // Đặt tiêu đề cột tiếng Việt cho đẹp
        private void DatTieuDeCot()
        {
            var tieuDe = new Dictionary<string, string>
            {
                ["MaSV"] = "Mã SV",
                ["HoTen"] = "Họ tên",
                ["MaLop"] = "Mã lớp",
                ["TenLop"] = "Tên lớp",
                ["Diem"] = "Điểm TB",
                ["KetQua"] = "Kết quả",
                ["SoLuong"] = "Số lượng",
                ["SoDat"] = "Số đạt",
                ["SoKhongDat"] = "Số không đạt",
                ["DiemTrungBinh"] = "Điểm TB lớp"
            };

            foreach (DataGridViewColumn col in dgvBaoCao.Columns)
            {
                if (tieuDe.TryGetValue(col.Name, out string text))
                    col.HeaderText = text;
            }
        }

        // ===================== SỰ KIỆN NÚT =====================
        private void btnXemBaoCao_Click(object sender, EventArgs e) => XemBaoCao();

        private void btnXuatFile_Click(object sender, EventArgs e) => XuatFile();
    }
}
