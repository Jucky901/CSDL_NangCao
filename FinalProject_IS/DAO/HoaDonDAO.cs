using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.DAO
{
    public class HoaDonDAO
    {
        public static List<HoaDon> LoadHoaDon()
        {
            using (var context = new ShopBadmintonEntities())
            {
                return context.HoaDons.ToList();
            }
        }
    }
}
