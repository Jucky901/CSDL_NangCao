using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAOs
{
    public class NhanVienDAO
    {
        public static List<NhanVien> DsNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM NhanVien";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = Convert.ToInt32(row["MaNV"]),
                        HoTen = row["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = row["GioiTinh"].ToString(),
                        Email = Convert.ToString(row["email"]),
                        MaChucVu = Convert.ToInt32(row["MaChucVu"]),
                        LuongCoBan = Convert.ToDecimal(row["LuongCoBan"])
                    };
                    dsNhanVien.Add(nv);
                }
            }

            return dsNhanVien;
        }
        public static void ThemNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"INSERT INTO NhanVien Values(@MaNV, @HoTen, @NgaySinh, @GioiTinh,
                                                                    @Email, @MaChucVu, @LuongCoBan)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                    cmd.Parameters.AddWithValue("@Email", nv.Email);
                    cmd.Parameters.AddWithValue("@MaChucVu", nv.MaChucVu);
                    cmd.Parameters.AddWithValue("@LuongCoBan", nv.LuongCoBan);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
