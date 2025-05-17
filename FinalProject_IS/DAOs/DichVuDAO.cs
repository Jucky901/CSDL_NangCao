using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAOs
{
    public class DichVuDAO
    {
        public static List<HoaDonDichVu> DSDichVu()
        {
            List<HoaDonDichVu> dsHoaDonDichVu = new List<HoaDonDichVu>();

            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                string query = "SELECT * FROM HoaDonDichVu";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    HoaDonDichVu hddv = new HoaDonDichVu
                    {
                        MaHDDV = Convert.ToInt32(row["MaHDDV"]),
                        NgayGioTao = Convert.ToDateTime(row["NgayGioTao"]),
                        MaKH = row["MaKH"] != DBNull.Value ? Convert.ToInt32(row["MaKH"]) : (int?)null,
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        MaNV = Convert.ToInt32(row["MaNV"]),
                        //TenVot = row["TenVot"].ToString(),
                        //LoaiDay = row["LoaiDay"].ToString(),
                        NgayGioLayVot = row["NgayGioLayVot"] != DBNull.Value ? Convert.ToDateTime(row["NgayGioLayVot"]) : (DateTime?)null,
                        //SoKG = Convert.ToInt32(row["SoKG"]),
                        ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null,
                        LoaiPhieu = row["LoaiPhieu"].ToString()
                    };
                    dsHoaDonDichVu.Add(hddv);
                }
            }

            return dsHoaDonDichVu;
        }
    }
}
