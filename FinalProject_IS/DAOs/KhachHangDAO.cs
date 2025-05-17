using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAOs
{
    public class KhachHangDAO
    {
        public static List<KhachHang> DSKhachHang()
        {
            List<KhachHang> dsKhachHang = new List<KhachHang>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM KhachHang";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    KhachHang kh = new KhachHang
                    {
                        MaKH = Convert.ToInt32(row["MaKH"]),
                        HoTen = row["HoTen"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        TongChiTieu = Convert.ToDecimal(row["TongChiTieu"]),
                        MaLoaiKH = Convert.ToInt32(row["MaLoaiKH"]),
                    };
                    dsKhachHang.Add(kh);
                }
            }

            return dsKhachHang;
        }
        public static KhachHang TimKiemKhachHangTheoSDT(string soDienThoai)
        {
            KhachHang khachHang = null;

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open(); // Mở kết nối đến database

                string query = "SELECT * FROM KhachHang WHERE SoDienThoai LIKE @SoDienThoai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", "%" + soDienThoai + "%"); // Tìm kiếm gần đúng

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu có dữ liệu
                        {
                            khachHang = new KhachHang
                            {
                                MaKH = Convert.ToInt32(reader["MaKH"]),
                                HoTen = reader["HoTen"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                TongChiTieu = reader["TongChiTieu"] as decimal?,
                                MaLoaiKH = reader["MaLoaiKH"] as int?
                            };
                        }
                    }
                }
            }

            return khachHang; // Trả về khách hàng hoặc null nếu không tìm thấy
        }
        public static bool ThemKhachHang(KhachHang khachHang)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open(); // Mở kết nối đến cơ sở dữ liệu

                string query = "INSERT INTO KhachHang (HoTen, SoDienThoai, TongChiTieu, MaLoaiKH) " +
                               "VALUES (@HoTen, @SoDienThoai, @TongChiTieu, @MaLoaiKH);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                    cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                    cmd.Parameters.AddWithValue("@TongChiTieu", khachHang.TongChiTieu ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaLoaiKH", khachHang.MaLoaiKH ?? (object)DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh INSERT

                    return rowsAffected > 0; // Trả về true nếu thêm thành công
                }
            }
        }
    }
}
