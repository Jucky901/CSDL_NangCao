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
    public class HoaDonDAO
    {
        public static List<HoaDon> DSHoaDon()
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM HoaDon";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    HoaDon hd = new HoaDon
                    {
                        MaHD = row["MaHD"].ToString(),
                        NgayGioTao = Convert.ToDateTime(row["NgayGioTao"]),
                        MaKH = Convert.ToInt32(row["MaKH"]),
                        MaNV = Convert.ToInt32(row["MaNV"]),
                        TongTien = Convert.ToInt32(row["TongTien"]),
                        MaKM = row["MaKM"] != DBNull.Value ? Convert.ToInt32(row["MaKM"]) : (int?)null,
                        LoaiHoaDon = row["LoaiHoaDon"].ToString()
                    };
                    dsHoaDon.Add(hd);
                }
            }

            return dsHoaDon;
        }
        public static List<ChiTietHD_SanPham> LayChiTietTheoMaHD(string id)
        {
            List<ChiTietHD_SanPham> ChiTietHD_SanPham = new List<ChiTietHD_SanPham>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = @"SELECT MaSP, SoLuongSP, DonGia, ThanhTien FROM ChiTietHD_SanPham where MaHD = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ChiTietHD_SanPham chitiet = new ChiTietHD_SanPham();
                        chitiet.MaHD = id;
                        chitiet.MaSP = Convert.ToInt32(row["MaSP"]);
                        chitiet.SoLuongSP = Convert.ToInt32(row["SoLuongSP"]);
                        chitiet.DonGia = Convert.ToDecimal(row["DonGia"]);
                        chitiet.ThanhTien = Convert.ToDecimal(row["ThanhTien"]);
                        ChiTietHD_SanPham.Add(chitiet);
                    }
                    return ChiTietHD_SanPham;
                }
            }
        }
    }
}
