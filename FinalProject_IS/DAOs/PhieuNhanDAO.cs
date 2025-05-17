using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace FinalProject_IS.DAOs
{
    public class PhieuNhanDAO
    {
        public static List<PhieuNhan> DSPhieuNhan()
        {
            List<PhieuNhan> dsPhieuNhan = new List<PhieuNhan>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM PhieuNhan";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    PhieuNhan pn = new PhieuNhan
                    {
                        MaPhieuNhan = Convert.ToInt32(row["MaPhieuNhan"]),
                        NgayTao = Convert.ToDateTime(row["NgayTao"]),
                    };
                    dsPhieuNhan.Add(pn);
                }
            }

            return dsPhieuNhan;
        }
        public static List<PhieuNhan> DSPhieuNhanTheoMa(string maphieu)
        {
            List<PhieuNhan> dsPhieuNhan = new List<PhieuNhan>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"SELECT * FROM PhieuNhan
                         WHERE MaPhieuNhan LIKE @maphieu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maphieu", maphieu + "%");

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        PhieuNhan sp = new PhieuNhan
                        {
                            MaPhieuNhan = Convert.ToInt32(row["MaPhieuNhan"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"])
                        };

                        dsPhieuNhan.Add(sp);
                    }
                }
            }

            return dsPhieuNhan;
        }
        public static List<PhieuNhan> DSSapXepPhieuNhan(string columnName, bool ascending)
        {
            List<PhieuNhan> dsPhieuNhan = new List<PhieuNhan>();

            if (!IsValidColumnName(columnName))
            {
                throw new ArgumentException("Tên cột không hợp lệ.");
            }

            string order = ascending ? "ASC" : "DESC"; // Chọn thứ tự sắp xếp
            string query = $@"SELECT * FROM PhieuNhan ORDER BY {columnName} {order}";

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuNhan sp = new PhieuNhan
                        {
                            MaPhieuNhan = reader.GetInt32(reader.GetOrdinal("MaPhieuNhan")),
                            NgayTao = reader.GetDateTime(reader.GetOrdinal("NgayTao"))
                        };

                        dsPhieuNhan.Add(sp);
                    }
                }
            }

            return dsPhieuNhan;
        }

        // Phương thức để kiểm tra tên cột
        private static bool IsValidColumnName(string columnName)
        {
            // Kiểm tra tên cột với danh sách các tên cột hợp lệ
            var validColumns = new List<string> { "MaPhieuNhan", "NgayTao" }; // Thêm các cột hợp lệ ở đây
            return validColumns.Contains(columnName);
        }

        public static void InsertPhieu(PhieuNhan phieu)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"INSERT INTO PhieuNhan Values(@NgayTao)";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayTao", phieu.NgayTao);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertChiTietPhieu(ChiTietPhieuNhan chitiet)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"INSERT INTO ChiTietPhieuNhan Values(@MaPhieuNhan, @MaSP, @TenSP, @LoaiSP
                                                                        ,@SoLuongNhap, @DonGiaNhap, @ThuongHieu
                                                                        ,@ThoiGianBaoHanh, @MoTa, @TongTien, @NgayNhan)";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhan", chitiet.MaPhieuNhan);
                    cmd.Parameters.AddWithValue("@MaSP", chitiet.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", chitiet.TenSP);
                    cmd.Parameters.AddWithValue("@LoaiSP", chitiet.LoaiSP);
                    cmd.Parameters.AddWithValue("@SoLuongNhap", chitiet.SoLuongNhap);
                    cmd.Parameters.AddWithValue("@DonGiaNhap", chitiet.DonGiaNhap);
                    cmd.Parameters.AddWithValue("@ThuongHieu", chitiet.ThuongHieu);
                    cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", chitiet.ThoiGianBaoHanh);
                    cmd.Parameters.AddWithValue("@MoTa", chitiet.MoTa);
                    cmd.Parameters.AddWithValue("@TongTien", chitiet.TongTien);
                    cmd.Parameters.AddWithValue("@NgayNhan", chitiet.NgayNhan);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int GetNewPhieuNhanID()
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();

                string query = "SELECT ISNULL(MAX(MaPhieuNhan), 0) FROM PhieuNhan";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int maxID = Convert.ToInt32(result);
                    return maxID + 1;
                }
            }
        }

        public static List<ChiTietPhieuNhan> GetChiTietByID(int id)
        {
            List<ChiTietPhieuNhan> ChitietPhieuNhanHang = new List<ChiTietPhieuNhan>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"SELECT * FROM ChiTietPhieuNhan where MaPhieuNhan = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ChiTietPhieuNhan chitiet = new ChiTietPhieuNhan();
                        chitiet.MaPhieuNhan = id;
                        chitiet.MaSP = Convert.ToInt32(row["MaSP"]);
                        chitiet.TenSP = row["TenSP"].ToString();
                        chitiet.LoaiSP = row["LoaiSP"].ToString();
                        chitiet.SoLuongNhap = Convert.ToInt32(row["SoLuongNhap"]);
                        chitiet.DonGiaNhap = Convert.ToDecimal(row["DonGiaNhap"]);
                        chitiet.ThuongHieu = row["ThuongHieu"].ToString();
                        chitiet.ThoiGianBaoHanh = Convert.ToInt32(row["ThoiGianBaoHanh"]);
                        chitiet.MoTa = row["Mota"].ToString();
                        chitiet.TongTien = Convert.ToDecimal(row["TongTien"]);
                        ChitietPhieuNhanHang.Add(chitiet);
                    }
                    return ChitietPhieuNhanHang;
                }
            }

        }
    }
}
