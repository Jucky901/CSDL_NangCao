using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace FinalProject_IS.DAOs
{
    public class SanPhamDAO
    {
        public static List<SanPham> DSSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT TOP 100 * FROM SanPham";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    SanPham sp = new SanPham
                    {
                        MaSP = Convert.ToInt32(row["MaSP"]),
                        TenSP = row["TenSP"].ToString(),
                        LoaiSP = row["LoaiSP"].ToString(),
                        GiaBan = Convert.ToDecimal(row["GiaBan"]),
                        SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                        NgayNhapKho = Convert.ToDateTime(row["NgayNhapKho"]),
                        ThoiGianBaoHanh = row["ThoiGianBaoHanh"] != DBNull.Value ? Convert.ToInt32(row["ThoiGianBaoHanh"]) : (int?)null,
                        GiaGoc = Convert.ToDecimal(row["GiaGoc"]),
                        MoTa = row["MoTa"].ToString()
                    };
                    dsSanPham.Add(sp);
                }
            }

            return dsSanPham;
        }

        public static int GetNewProductID()
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();

                string query = "SELECT ISNULL(MAX(MaSP), 0) FROM SanPham";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int maxID = Convert.ToInt32(result);
                    return maxID + 1; 
                }
            }
        }

        public static string GetProductNameByID(int productID)  
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();

                string query = "Select TenSP From SanPham where MaSP = @productID;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productID", productID);
                    object result = cmd.ExecuteScalar();
                    string name = result.ToString();
                    return name;
                }
            }
        }

        public static SanPham GetProductByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();

                string query = "SELECT * FROM SanPham WHERE MaSP = @productID;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SanPham product = new SanPham();
                            product.MaSP = reader.GetInt32(reader.GetOrdinal("MaSP"));
                            product.TenSP = reader.GetString(reader.GetOrdinal("TenSP"));
                            product.LoaiSP = reader.GetString(reader.GetOrdinal("LoaiSP"));
                            product.GiaBan = reader.GetDecimal(reader.GetOrdinal("GiaBan"));
                            product.SoLuongTon = reader.GetInt32(reader.GetOrdinal("SoLuongTon"));
                            product.NgayNhapKho = reader.GetDateTime(reader.GetOrdinal("NgayNhapKho"));
                            product.ThoiGianBaoHanh = reader.GetInt32(reader.GetOrdinal("ThoiGianBaoHanh"));
                            product.MaTH = reader.GetInt32(reader.GetOrdinal("MaTH"));
                            product.GiaGoc = reader.GetDecimal(reader.GetOrdinal("GiaGoc"));
                            product.MoTa = reader.GetString(reader.GetOrdinal("MoTa"));
                            return product;
                        }
                        else
                        {
                            return null; // or throw an exception, depending on your needs
                        }
                    }
                }
            }
        }
        public static SanPham TimSanPhamTheoMaSP(string maSP)
        {
            SanPham sanPham = null;

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open(); // Mở kết nối đến database

                string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP); // Truyền tham số an toàn

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy sản phẩm
                        {
                            sanPham = new SanPham
                            {
                                MaSP = Convert.ToInt32(reader["MaSP"]),
                                TenSP = reader["TenSP"].ToString(),
                                LoaiSP = reader["LoaiSP"].ToString(),
                                GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                                SoLuongTon = reader["SoLuongTon"] as int?,
                                NgayNhapKho = Convert.ToDateTime(reader["NgayNhapKho"]),
                                ThoiGianBaoHanh = reader["ThoiGianBaoHanh"] as int?,
                                MaTH = reader["MaTH"] as int?,
                                GiaGoc = Convert.ToDecimal(reader["GiaGoc"]),
                                MoTa = reader["MoTa"].ToString()
                            };
                        }
                    }

                    return sanPham;
                }
            }
        }

        public static void UpdateSanPhamNhan(int id, int soluong)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"UPDATE SanPham
                        SET SoLuongTon = SoLuongTon + @soluong
                        WHERE MaSP = @id;
                        ";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@soluong", soluong);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
