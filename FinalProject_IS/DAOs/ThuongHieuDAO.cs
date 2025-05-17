using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAOs
{
    public class ThuongHieuDAO
    {
        public static string GetTenThuongHieuByID(int? id)
        {
            using (SqlConnection conn = new SqlConnection(DataProvider.ConnStr))
            {
                conn.Open();

                string query = "Select TenTH From ThuongHieu where MaTH = @productID;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productID", id);
                    object result = cmd.ExecuteScalar();
                    string name = result.ToString();
                    return name;
                }
            }
        }
    }
}
