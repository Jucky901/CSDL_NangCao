using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_IS.DAO.NhanVienDAO;

namespace FinalProject_IS.DAO
{
    public class SanPhamDAO
    {
        public static List<SanPham> LoadSanPham()
        {
            using (var context = new ShopBadmintonEntities())
            {
                return context.SanPhams.ToList();
            }
        }
    }
}
