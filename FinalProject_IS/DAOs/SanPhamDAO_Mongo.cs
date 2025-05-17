using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinalProject_IS.DAOs
{
    public class SanPhamDAO_Mongo
    {
        public static List<SanPham> DSSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();

            // Get the "SanPham" collection from the CauLong database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("SanPham");

            // Fetch the top 100 documents
            var filter = Builders<BsonDocument>.Filter.Empty;
            var documents = collection.Find(filter).Limit(100).ToList();

            foreach (var doc in documents)
            {
                SanPham sp = new SanPham
                {
                    MaSP = doc.Contains("MaSP") ? doc["MaSP"].AsInt32 : 0,
                    TenSP = doc.Contains("TenSP") ? doc["TenSP"].AsString : string.Empty,
                    LoaiSP = doc.Contains("LoaiSP") ? doc["LoaiSP"].AsString : string.Empty,
                    GiaBan = doc.Contains("GiaBan") ? doc["GiaBan"].AsDouble : 0.0,
                    SoLuongTon = doc.Contains("SoLuongTon") ? doc["SoLuongTon"].AsInt32 : 0,
                    NgayNhapKho = doc.Contains("NgayNhapKho") ? doc["NgayNhapKho"].ToUniversalTime() : DateTime.MinValue,
                    ThoiGianBaoHanh = doc.Contains("ThoiGianBaoHanh") && doc["ThoiGianBaoHanh"] != BsonNull.Value
                                      ? doc["ThoiGianBaoHanh"].AsInt32
                                      : (int?)null,
                    GiaGoc = doc.Contains("GiaGoc") ? doc["GiaGoc"].AsDouble : 0.0,
                    MoTa = doc.Contains("MoTa") ? doc["MoTa"].AsString : string.Empty
                };

                dsSanPham.Add(sp);
            }

            return dsSanPham;
        }
    }
}
