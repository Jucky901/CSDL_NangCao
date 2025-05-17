using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace FinalProject_IS.DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVien> LoadNhanVien()
        {
            using (var context = new ShopBadmintonEntities())
            {
                return context.NhanViens.ToList();
            }
        }

        //public static NhanVien GetById(int id)
        //{
        //    using (var context = new YourDbContext())
        //    {
        //        return context.NhanViens
        //                      .Include(nv => nv.ChucVu)
        //                      .FirstOrDefault(nv => nv.MaNV == id);
        //    }
        //}

        //public static void Add(NhanVien nv)
        //{
        //    using (var context = new YourDbContext())
        //    {
        //        context.NhanViens.Add(nv);
        //        context.SaveChanges();
        //    }
        //}

        //// Add Update, Delete, Search as needed
    }
}
