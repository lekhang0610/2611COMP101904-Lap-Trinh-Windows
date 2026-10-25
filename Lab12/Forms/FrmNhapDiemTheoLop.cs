using System.Data;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL dal = new KetQuaDAL();
        private readonly BindingSource bs = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            try
            {
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = dal.GetLop();
                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = dal.GetMonHoc();
                dgvKetQua.DataSource = bs;
                lblTrangThai.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được database: " + ex.Message);
                lblTrangThai.Text = "Lỗi kết nối";
            }
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";
            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.");
                return;
            }
            try
            {
                bs.DataSource = dal.GetKetQuaByLopMon(maLop, maMon);
                dgvKetQua.Columns["MaSV"]!.ReadOnly = true;
                dgvKetQua.Columns["HoTen"]!.ReadOnly = true;
                dgvKetQua.Columns["MaSV"]!.HeaderText = "Mã SV";
                dgvKetQua.Columns["HoTen"]!.HeaderText = "Họ tên";
                dgvKetQua.Columns["Diem"]!.HeaderText = "Điểm";
                dgvKetQua.Columns["GhiChu"]!.HeaderText = "Ghi chú";
                lblTrangThai.Text = $"Đã tải {bs.Count} sinh viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách: " + ex.Message);
            }
        }

        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            if (bs.DataSource is not DataTable table || table.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để lưu.");
                return;
            }
            try
            {
                dgvKetQua.EndEdit();
                bs.EndEdit();
                ValidateData(table);
                int count = dal.SaveAll(cboMonHoc.SelectedValue?.ToString() ?? "", table);
                lblTrangThai.Text = $"Đã lưu {count} dòng";
                MessageBox.Show($"Đã lưu thành công {count} dòng.");
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lưu thất bại, đã hủy toàn bộ";
                MessageBox.Show("Không thể lưu dữ liệu: " + ex.Message);
            }
        }

        private void ValidateData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                string maSV = row["MaSV"].ToString() ?? "";
                if (row["Diem"] == DBNull.Value || row["Diem"].ToString()!.Trim().Length == 0)
                    throw new Exception($"Điểm của sinh viên {maSV} không được rỗng.");
                if (!double.TryParse(row["Diem"].ToString(), out double d))
                    throw new Exception($"Điểm của sinh viên {maSV} không hợp lệ.");
                if (d < 0 || d > 10)
                    throw new Exception($"Điểm của sinh viên {maSV} phải từ 0 đến 10.");
            }
        }

        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Điểm phải là số hợp lệ.");
            e.ThrowException = false;
            e.Cancel = false;
        }
    }
}
