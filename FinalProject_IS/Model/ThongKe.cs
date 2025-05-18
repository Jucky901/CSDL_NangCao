using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.Model
{
    internal static class ThongKe
    {
        public class DoanhThuTheoNgay
        {
            public int Ngay { get; set; }
            public decimal DoanhThu { get; set; }
        }

        public class DoanhThuTheoThang
        {
            public int Thang { get; set; }
            public decimal DoanhThu { get; set; }
        }

        public class TopSanPham
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public int DoanhSo { get; set; }
            public decimal DoanhThu { get; set; }
        }

        public class TopLoiNhuan : TopSanPham
        {
            public decimal LoiNhuan { get; set; }
        }
    }
}