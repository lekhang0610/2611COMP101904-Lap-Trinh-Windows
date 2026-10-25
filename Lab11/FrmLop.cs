using System.Data;
using Microsoft.Data.SqlClient;

namespace COMP1019_Buoi11_Lab11
{
    public partial class FrmLop : Form
    {
        private const string cs =
            @"Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        private SqlCommand MakeCmd(SqlConnection conn, string sql, (string, object)[] ps)
        {
            var cmd = new SqlCommand(sql, conn);
            foreach (var (name, val) in ps) cmd.Parameters.AddWithValue(name, val);
            return cmd;
        }

        private DataTable GetTable(string sql, params (string, object)[] ps)
        {
            using var conn = new SqlConnection(cs);
            using var cmd = MakeCmd(conn, sql, ps);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private int Exec(string sql, params (string, object)[] ps)
        {
            using var conn = new SqlConnection(cs);
            using var cmd = MakeCmd(conn, sql, ps);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        private int Count(string sql, params (string, object)[] ps)
        {
            using var conn = new SqlConnection(cs);
            using var cmd = MakeCmd(conn, sql, ps);
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string kw = "")
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
                               WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw
                               GROUP BY l.MaLop, l.TenLop
                               ORDER BY l.MaLop";
                dgvLop.DataSource = GetTable(sql, ("@kw", "%" + kw + "%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp");
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp");
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        private bool IsMaLopExists(string ma)
        {
            return Count("SELECT COUNT(*) FROM LOP WHERE MaLop = @ma", ("@ma", ma)) > 0;
        }

        private int CountSinhVienByLop(string ma)
        {
            return Count("SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma", ("@ma", ma));
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
            txtMaLop.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp đã tồn tại");
                    return;
                }
                if (Exec("INSERT INTO LOP(MaLop, TenLop) VALUES(@ma, @ten)", ("@ma", ma), ("@ten", ten)) > 0)
                {
                    MessageBox.Show("Thêm lớp thành công");
                    ClearInput();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!txtMaLop.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa trong danh sách");
                return;
            }
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            try
            {
                if (Exec("UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma", ("@ma", ma), ("@ten", ten)) > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công");
                    ClearInput();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            if (!txtMaLop.ReadOnly || ma == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa trong danh sách");
                return;
            }
            try
            {
                if (CountSinhVienByLop(ma) > 0)
                {
                    MessageBox.Show("Không thể xóa lớp đang có sinh viên");
                    return;
                }
                var rs = MessageBox.Show("Bạn có chắc muốn xóa lớp " + ma + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No) return;

                if (Exec("DELETE FROM LOP WHERE MaLop = @ma", ("@ma", ma)) > 0)
                {
                    MessageBox.Show("Xóa lớp thành công");
                    ClearInput();
                    LoadData();
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Không thể xóa lớp vì còn dữ liệu liên quan (khóa ngoại)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }
    }
}
