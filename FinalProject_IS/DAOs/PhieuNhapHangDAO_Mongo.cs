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
    public class PhieuNhapHangDAO_Mongo
    {
        public static List<PhieuNhapHang> DSPhieuNhap()
        {
            List<PhieuNhapHang> dsPhieuNhap = new List<PhieuNhapHang>();

            var collection = MongoConnection.Database.GetCollection<BsonDocument>("PhieuNhapHang");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                PhieuNhapHang pn = new PhieuNhapHang
                {
                    MaPhieuNhap = doc.Contains("MaPhieuNhap") ? doc["MaPhieuNhap"].AsInt32 : 0,
                    NgayTao = doc.Contains("NgayTao") ? doc["NgayTao"].ToUniversalTime() : DateTime.MinValue,
                    TinhTrangPhieuNhap = doc.Contains("TinhTrangPhieuNhap") ? doc["TinhTrangPhieuNhap"].AsString : string.Empty,
                    SanPham = new List<SanPhamPhieuNhap>()
                };

                // Handle embedded list of SanPhamPhieuNhap
                if (doc.Contains("SanPham") && doc["SanPham"].IsBsonArray)
                {
                    var spArray = doc["SanPham"].AsBsonArray;
                    foreach (var spDoc in spArray)
                    {
                        var sp = spDoc.AsBsonDocument;
                        SanPhamPhieuNhap sanPhamPhieuNhap = new SanPhamPhieuNhap
                        {
                            MaSP = sp.Contains("MaSP") ? sp["MaSP"].AsInt32 : 0,
                            TenSP = sp.Contains("TenSP") ? sp["TenSP"].AsString : string.Empty,
                            SoLuongNhap = sp.Contains("SoLuongNhap") ? sp["SoLuongNhap"].AsInt32 : 0,
                            SoLuongThieu = sp.Contains("SoLuongThieu") ? sp["SoLuongThieu"].AsInt32 : 0,
                        };

                        pn.SanPham.Add(sanPhamPhieuNhap);
                    }
                }

                dsPhieuNhap.Add(pn);
            }

            return dsPhieuNhap;
        }


        public static void InsertPhieuNhap(PhieuNhapHang phieuNhap)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            try
            {
                phieuNhap.MaPhieuNhap = SequenceDAO.GetNextSequenceValue("PhieuNhap");
                // Ensure TinhTrangPhieuNhap is not null
                if (string.IsNullOrEmpty(phieuNhap.TinhTrangPhieuNhap))
                {
                    phieuNhap.TinhTrangPhieuNhap = "Chưa duyệt"; // or any default status string
                }
                collection.InsertOne(phieuNhap);
                Console.WriteLine("PhieuNhap inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting Phieu Nhap: {ex.Message}");
            }
        }

        public static List<SanPhamPhieuNhap> GetPhieuNhapById(int maPhieuNhap)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.Eq("MaPhieuNhap", maPhieuNhap);
            var phieuNhap = collection.Find(filter).FirstOrDefault();
            if (phieuNhap != null)
            {
                return phieuNhap.SanPham;
            }
            else
            {
                return null;
            }
        }

        public static List<PhieuNhapHang> GetPhieuNhapChuaDuyetByMaSP(int maSP)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.And(
                Builders<PhieuNhapHang>.Filter.Eq("TinhTrangPhieuNhap", "Chưa duyệt"),
                Builders<PhieuNhapHang>.Filter.ElemMatch("SanPham", Builders<SanPhamPhieuNhap>.Filter.Eq("MaSP", maSP))
            );
            return collection.Find(filter).ToList();
        }

        public static void UpdateSoLuongThieu(ObjectId id, int soLuongThieu)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.Eq("_id", id);
            var update = Builders<PhieuNhapHang>.Update.Set("SanPham.$[elem].SoLuongThieu", soLuongThieu);
            var arrayFilters = new List<ArrayFilterDefinition>
            {
                new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("elem.MaSP", id))
            };
            var options = new UpdateOptions { ArrayFilters = arrayFilters };
            collection.UpdateOne(filter, update, options);
        }

        public static void UpdatePhieuNhapHang(PhieuNhapHang phieuNhap)
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.Eq("MaPhieuNhap", phieuNhap.MaPhieuNhap);
            var update = Builders<PhieuNhapHang>.Update
                .Set("SanPham", phieuNhap.SanPham)
                .Set("TinhTrangPhieuNhap", phieuNhap.TinhTrangPhieuNhap);
            collection.UpdateOne(filter, update);
        }

        public static void UpdateTinhTrangPhieuNhap()
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.Eq("TinhTrangPhieuNhap", "Chưa duyệt");
            var phieuNhapList = collection.Find(filter).ToList();

            foreach (var phieuNhap in phieuNhapList)
            {
                // Check if all SoLuongThieu are 0
                bool allEnough = phieuNhap.SanPham != null &&
                                 phieuNhap.SanPham.All(sp => sp.SoLuongThieu == 0);

                if (allEnough)
                {
                    var update = Builders<PhieuNhapHang>.Update.Set("TinhTrangPhieuNhap", "Đủ");
                    var updateFilter = Builders<PhieuNhapHang>.Filter.Eq("_id", phieuNhap.Id);
                    collection.UpdateOne(updateFilter, update);
                }
            }
        }

        public static List<PhieuNhapHang> DSPhieuNhapHangOrderbyMaPhieuNhap()
        {
            var collection = MongoConnection.Database.GetCollection<PhieuNhapHang>("PhieuNhapHang");
            var filter = Builders<PhieuNhapHang>.Filter.Empty;
            var sort = Builders<PhieuNhapHang>.Sort.Ascending("MaPhieuNhap");
            return collection.Find(filter).Sort(sort).ToList();
        }
    }
}
