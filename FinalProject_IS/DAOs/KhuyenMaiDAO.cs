using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAOs
{
    public class KhuyenMaiDAO
    {
        public static List<KhuyenMai> DsKhuyenMai()
        {
            List<KhuyenMai> dsKhuyenMai = new List<KhuyenMai>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM KhuyenMai";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    KhuyenMai km = new KhuyenMai
                    {
                        MaKM = Convert.ToInt32(row["MaKM"]),
                        TenChuongTrinh = row["TenChuongTrinh"].ToString(),
                        GiaTriKhuyenMai = Convert.ToDouble(row["GiaTriKhuyenMai"]),
                        DieuKienKhuyenMai = row["DieuKienKhuyenMai"].ToString(),
                        NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                        NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]),
                        SoLuong = Convert.ToInt32(row["SoLuong"])
                    };
                    dsKhuyenMai.Add(km);
                }
            }

            return dsKhuyenMai;
        }
        public static void InsertKhuyenMai(KhuyenMai khuyenMai)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"INSERT INTO KhuyenMai Values(@TenChuongTrinh, @GiaTriKhuyenMai, @DieuKienKhuyenMai,
                                @NgayBatDau,@NgayKetThuc,@SoLuong)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenChuongTrinh", khuyenMai.TenChuongTrinh);
                    cmd.Parameters.AddWithValue("@GiaTriKhuyenMai", khuyenMai.GiaTriKhuyenMai);
                    cmd.Parameters.AddWithValue("@DieuKienKhuyenMai", khuyenMai.DieuKienKhuyenMai);
                    cmd.Parameters.AddWithValue("@NgayBatDau", khuyenMai.NgayBatDau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", khuyenMai.NgayKetThuc);
                    cmd.Parameters.AddWithValue("@SoLuong", khuyenMai.SoLuong);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static int XoaKhuyenMai(int maKM)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"DELETE FROM KhuyenMai WHERE MaKM = @MaKM";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKM", maKM);

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;

        }

        
        public static int XoaNhieuKhuyenMai(List<int> danhSachMaKM)
        {
            int rowsAffected = 0;
            foreach (int maKM in danhSachMaKM)
            {
                rowsAffected += XoaKhuyenMai(maKM);
            }
            return rowsAffected;
        }
    }
}
