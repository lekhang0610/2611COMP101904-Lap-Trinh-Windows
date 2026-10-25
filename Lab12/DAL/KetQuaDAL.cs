using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public class KetQuaDAL
    {
        private DataTable Query(string proc, params SqlParameter[] ps)
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            using var cmd = new SqlCommand(proc, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddRange(ps);
            using var da = new SqlDataAdapter(cmd);
            var t = new DataTable();
            da.Fill(t);
            return t;
        }

        public DataTable GetLop() => Query("sp_Lop_GetAll");

        public DataTable GetMonHoc() => Query("sp_MonHoc_GetAll");

        public DataTable GetKetQuaByLopMon(string maLop, string maMon) =>
            Query("sp_KetQua_GetByLopMon",
                new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop },
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });

        public int SaveAll(string maMon, DataTable table)
        {
            using var conn = new SqlConnection(Database.ConnectionString);
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    using var cmd = new SqlCommand("sp_KetQua_Save", conn, trans)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20).Value = row["MaSV"].ToString();
                    cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                    cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = Convert.ToDouble(row["Diem"]);
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value = row["GhiChu"].ToString() ?? "";
                    cmd.ExecuteNonQuery();
                    count++;
                }
                trans.Commit();
                return count;
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }
    }
}
