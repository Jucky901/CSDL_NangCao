using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_IS.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinalProject_IS.DAOs
{
    public class PhieuNhanHangDAO_Mongo
    {
        public static List<PhieuNhanHang> DSPhieuNhan()
        {
            List<PhieuNhanHang> dsPhieuNhan = new List<PhieuNhanHang>();

            var collection = MongoConnection.Database.GetCollection<BsonDocument>("PhieuNhanHang");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                PhieuNhanHang pn = new PhieuNhanHang
                {
                    MaPhieuNhan = doc.Contains("MaPhieuNhan") ? doc["MaPhieuNhan"].AsInt32 : 0,
                    NgayNhan = doc.Contains("NgayNhan") ? doc["NgayNhan"].ToUniversalTime() : DateTime.MinValue,
                    SanPham = new List<SanPhamPhieuNhan>()
                };

                if (doc.Contains("SanPham") && doc["SanPham"].IsBsonArray)
                {
                    var spArray = doc["SanPham"].AsBsonArray;
                    foreach (var spDoc in spArray)
                    {
                        var sp = spDoc.AsBsonDocument;
                        SanPhamPhieuNhan sanPham = new SanPhamPhieuNhan
                        {
                            MaSP = sp.Contains("MaSP") ? sp["MaSP"].AsInt32 : 0,
                            TenSP = sp.Contains("TenSP") ? sp["TenSP"].AsString : string.Empty,
                            SoLuongNhap = sp.Contains("SoLuongNhap") ? sp["SoLuongNhap"].AsInt32 : 0,
                            DonGiaNhap = sp.Contains("DonGiaNhap") ? sp["DonGiaNhap"].AsDouble : 0.0,
                            ThuongHieu = sp.Contains("ThuongHieu") ? sp["ThuongHieu"].AsString : string.Empty,
                            ThoiGianBaoHanh = sp.Contains("ThoiGianBaoHanh") ? sp["ThoiGianBaoHanh"].AsInt32 : 0,
                            MoTa = sp.Contains("MoTa") ? sp["MoTa"].AsString : string.Empty,
                            TongTien = sp.Contains("TongTien") ? sp["TongTien"].AsDouble : 0.0
                        };

                        pn.SanPham.Add(sanPham);
                    }
                }

                dsPhieuNhan.Add(pn);
            }

            return dsPhieuNhan;
        }

        public static void InsertPhieuNhan(PhieuNhanHang phieuNhan)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhanHang>("PhieuNhanHang");

            try
            {
                // Get the next MaPhieuNhan value
                phieuNhan.MaPhieuNhan = SequenceDAO.GetNextSequenceValue("PhieuNhan");

                // Insert the PhieuNhan
                collection.InsertOne(phieuNhan);
                Console.WriteLine("PhieuNhan inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting PhieuNhan: {ex.Message}");
            }
        }

        public static List<SanPhamPhieuNhan> GetPhieuNhanById(int maPhieuNhan)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhanHang>("PhieuNhanHang");
            var filter = Builders<PhieuNhanHang>.Filter.Eq("MaPhieuNhan", maPhieuNhan);
            var phieuNhan = collection.Find(filter).FirstOrDefault();
            return phieuNhan != null ? phieuNhan.SanPham : new List<SanPhamPhieuNhan>();
        }
    }
}
