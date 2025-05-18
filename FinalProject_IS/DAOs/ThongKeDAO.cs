using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_IS.Model.ThongKe;

namespace FinalProject_IS.DAOs
{
    internal class ThongKeDAO
    {
        private static readonly IMongoDatabase _db = MongoConnection.Database;
        private static readonly IMongoCollection<BsonDocument> _hdSpCol = _db.GetCollection<BsonDocument>("HoaDonSanPham");
        private static readonly IMongoCollection<BsonDocument> _hdDvCol = _db.GetCollection<BsonDocument>("HoaDonDichVu");
        private static readonly IMongoCollection<BsonDocument> _spCol = _db.GetCollection<BsonDocument>("SanPham");

        // 1. Doanh thu theo ngày trong tháng
        public static List<DoanhThuTheoNgay> DSDoanhThuTheoThang(int month, int year)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);

            var pipeSp = new[] {
                new BsonDocument("$match", new BsonDocument("NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}})),
                new BsonDocument("$project", new BsonDocument{{"Ngay", new BsonDocument("$dayOfMonth","$NgayGioTao")},{"DoanhThu","$TongTien"}})
            };
            var pipeDv = new[] {
                new BsonDocument("$match", new BsonDocument{{"LoaiPhieu","DV"},{"NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}}}}),
                new BsonDocument("$project", new BsonDocument{{"Ngay", new BsonDocument("$dayOfMonth","$NgayGioTao")},{"DoanhThu","$ThanhTien"}})
            };

            var listSp = _hdSpCol.Aggregate<BsonDocument>(pipeSp).ToList();
            var listDv = _hdDvCol.Aggregate<BsonDocument>(pipeDv).ToList();

            return listSp.Concat(listDv)
                .GroupBy(d => d["Ngay"].AsInt32)
                .Select(g => new DoanhThuTheoNgay { Ngay = g.Key, DoanhThu = g.Sum(x => x["DoanhThu"].ToDecimal()) })
                .OrderBy(x => x.Ngay)
                .ToList();
        }

        // 2. Doanh thu theo tháng trong năm
        public static List<DoanhThuTheoThang> DSDoanhThuTheoNam(int year)
        {
            var start = new DateTime(year, 1, 1);
            var end = start.AddYears(1);

            var pipeSp = new[] {
                new BsonDocument("$match", new BsonDocument("NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}})),
                new BsonDocument("$project", new BsonDocument{{"Thang", new BsonDocument("$month","$NgayGioTao")},{"DoanhThu","$TongTien"}})
            };
            var pipeDv = new[] {
                new BsonDocument("$match", new BsonDocument{{"LoaiPhieu","DV"},{"NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}}}}),
                new BsonDocument("$project", new BsonDocument{{"Thang", new BsonDocument("$month","$NgayGioTao")},{"DoanhThu","$ThanhTien"}})
            };

            var listSp = _hdSpCol.Aggregate<BsonDocument>(pipeSp).ToList();
            var listDv = _hdDvCol.Aggregate<BsonDocument>(pipeDv).ToList();

            return listSp.Concat(listDv)
                .GroupBy(d => d["Thang"].AsInt32)
                .Select(g => new DoanhThuTheoThang { Thang = g.Key, DoanhThu = g.Sum(x => x["DoanhThu"].ToDecimal()) })
                .OrderBy(x => x.Thang)
                .ToList();
        }

        // 3. Top 10 sản phẩm bán chạy
        public static List<TopSanPham> DSTopBanChay()
        {
            var pipeline = new[] {
                new BsonDocument("$unwind","$SanPham"),
                new BsonDocument("$group", new BsonDocument{{"_id","$SanPham.MaSP"},{"DoanhSo", new BsonDocument("$sum","$SanPham.SoLuong")},{"DoanhThu", new BsonDocument("$sum", new BsonDocument("$multiply", new BsonArray{"$SanPham.SoLuong","$SanPham.DonGia"}))}}),
                new BsonDocument("$sort", new BsonDocument("DoanhSo", -1)),
                new BsonDocument("$limit", 10),
                new BsonDocument("$lookup", new BsonDocument{{"from","SanPham"},{"localField","_id"},{"foreignField","MaSP"},{"as","spInfo"}}),
                new BsonDocument("$unwind","$spInfo"),
                new BsonDocument("$project", new BsonDocument{{"MaSP","$_id"},{"TenSP","$spInfo.TenSP"},{"DoanhSo",1},{"DoanhThu",1},{"_id",0}})
            };
            return _hdSpCol.Aggregate<TopSanPham>(pipeline).ToList();
        }

        // 4. Top 10 sản phẩm lợi nhuận
        public static List<TopSanPham> DSLoiNhuanCao()
        {
            var pipeline = new[] {
                new BsonDocument("$unwind","$SanPham"),
                new BsonDocument("$lookup", new BsonDocument{{"from","SanPham"},{"localField","SanPham.MaSP"},{"foreignField","MaSP"},{"as","info"}}),
                new BsonDocument("$unwind","$info"),
                new BsonDocument("$project", new BsonDocument{{"MaSP","$SanPham.MaSP"},{"TenSP","$info.TenSP"},{"DoanhSo","$SanPham.SoLuong"},{"DoanhThu", new BsonDocument("$multiply", new BsonArray{"$SanPham.SoLuong","$SanPham.DonGia"})},{"LoiNhuan", new BsonDocument("$multiply", new BsonArray{"$SanPham.SoLuong", new BsonDocument("$subtract", new BsonArray{"$SanPham.ДonGia","$info.GiaGoc"})})}}),
                new BsonDocument("$group", new BsonDocument{{"_id", new BsonDocument{{"MaSP","$MaSP"},{"TenSP","$TenSP"}}},{"DoanhSo", new BsonDocument("$sum","$DoanhSo")},{"DoanhThu", new BsonDocument("$sum","$DoanhThu")},{"LoiNhuan", new BsonDocument("$sum","$LoiNhuan")}}),
                new BsonDocument("$sort", new BsonDocument("LoiNhuan", -1)),
                new BsonDocument("$limit", 10),
                new BsonDocument("$project", new BsonDocument{{"MaSP","$_id.MaSP"},{"TenSP","$_id.TenSP"},{"DoanhSo",1},{"DoanhThu",1},{"_id",0}})
            };
            return _hdSpCol.Aggregate<TopSanPham>(pipeline).ToList();
        }

        // 5. Lợi nhuận theo ngày trong tháng
        public static List<DoanhThuTheoNgay> DSLoiNhuanTheoThang(int month, int year)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);
            var pipeSp = new[] {
                new BsonDocument("$match", new BsonDocument("NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}})),
                new BsonDocument("$unwind","$SanPham"),
                new BsonDocument("$lookup", new BsonDocument{{"from","SanPham"},{"localField","SanPham.MaSP"},{"foreignField","MaSP"},{"as","info"}}),
                new BsonDocument("$unwind","$info"),
                new BsonDocument("$project", new BsonDocument{{"Ngay", new BsonDocument("$dayOfMonth","$NgayGioTao")},{"DoanhThu", new BsonDocument("$multiply", new BsonArray{"$SanPham.SoLuong", new BsonDocument("$subtract", new BsonArray{"$SanPham.DonGia","$info.GiaGoc"})})}})
            };
            var pipeDv = new[] {
                new BsonDocument("$match", new BsonDocument{{"LoaiPhieu","DV"},{"NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}}}}),
                new BsonDocument("$project", new BsonDocument{{"Ngay", new BsonDocument("$dayOfMonth","$NgayGioTao")},{"DoanhThu","$ThanhTien"}})
            };
            var listSp = _hdSpCol.Aggregate<BsonDocument>(pipeSp).ToList();
            var listDv = _hdDvCol.Aggregate<BsonDocument>(pipeDv).ToList();
            return listSp.Concat(listDv)
                .GroupBy(d => d["Ngay"].AsInt32)
                .Select(g => new DoanhThuTheoNgay { Ngay = g.Key, DoanhThu = g.Sum(x => x["DoanhThu"].ToDecimal()) })
                .OrderBy(x => x.Ngay)
                .ToList();
        }

        // 6. Lợi nhuận theo tháng trong năm
        public static List<DoanhThuTheoThang> DSLoiNhuanTheoNam(int year)
        {
            var start = new DateTime(year, 1, 1);
            var end = start.AddYears(1);
            var pipeSp = new[] {
                new BsonDocument("$match", new BsonDocument("NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}})),
                new BsonDocument("$unwind","$SanPham"),
                new BsonDocument("$lookup", new BsonDocument{{"from","SanPham"},{"localField","SanPham.MaSP"},{"foreignField","MaSP"},{"as","info"}}),
                new BsonDocument("$unwind","$info"),
                new BsonDocument("$project", new BsonDocument{{"Thang", new BsonDocument("$month","$NgayGioTao")},{"DoanhThu", new BsonDocument("$multiply", new BsonArray{"$SanPham.SoLuong", new BsonDocument("$subtract", new BsonArray{"$SanPham.DonGia","$info.GiaGoc"})})}})
            };
            var pipeDv = new[] {
                new BsonDocument("$match", new BsonDocument{{"LoaiPhieu","DV"},{"NgayGioTao", new BsonDocument{{"$gte", start},{"$lt", end}}}}),
                new BsonDocument("$project", new BsonDocument{{"Thang", new BsonDocument("$month","$NgayGioTao")},{"DoanhThu","$ThanhTien"}})
            };
            var listSp = _hdSpCol.Aggregate<BsonDocument>(pipeSp).ToList();
            var listDv = _hdDvCol.Aggregate<BsonDocument>(pipeDv).ToList();
            return listSp.Concat(listDv)
                .GroupBy(d => d["Thang"].AsInt32)
                .Select(g => new DoanhThuTheoThang { Thang = g.Key, DoanhThu = g.Sum(x => x["DoanhThu"].ToDecimal()) })
                .OrderBy(x => x.Thang)
                .ToList();
        }
    }
}
