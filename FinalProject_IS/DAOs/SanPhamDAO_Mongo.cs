using System;
using System.Collections.Generic;
using FinalProject_IS.Model;
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

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                SanPham sp = new SanPham
                {
                    MaSP = doc.Contains("MaSP") ? doc["MaSP"].AsInt32 : 0,
                    TenSP = doc.Contains("TenSP") ? doc["TenSP"].AsString : string.Empty,
                    LoaiSP = doc.Contains("LoaiSP") ? doc["LoaiSP"].AsString : string.Empty,
                    GiaSP = doc.Contains("GiaSP") ? doc["GiaSP"].AsDouble : 0.0,
                    SoLuongTon = doc.Contains("SoLuongTon") ? doc["SoLuongTon"].AsInt32 : 0,
                    NgayNhapKho = doc.Contains("NgayNhapKho") ? doc["NgayNhapKho"].ToUniversalTime() : DateTime.MinValue,
                    ThoiGianBaoHanh = doc.Contains("ThoiGianBaoHanh") && doc["ThoiGianBaoHanh"] != BsonNull.Value
                                      ? doc["ThoiGianBaoHanh"].AsInt32
                                      : (int?)null,
                    ThuongHieu = doc.Contains("ThuongHieu") ? doc["ThuongHieu"].AsString : string.Empty,
                    GiaGoc = doc.Contains("GiaGoc") ? doc["GiaGoc"].AsDouble : 0.0,
                    MoTa = doc.Contains("MoTa") ? doc["MoTa"].AsString : string.Empty
                };

                dsSanPham.Add(sp);
            }

            return dsSanPham;
        }

        public static SanPham GetProductByID(int id)
        {
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("SanPham");
            var filter = Builders<BsonDocument>.Filter.Eq("MaSP", id);
            var document = collection.Find(filter).FirstOrDefault();
            if (document != null)
            {
                return new SanPham
                {
                    MaSP = document.Contains("MaSP") ? document["MaSP"].AsInt32 : 0,
                    TenSP = document.Contains("TenSP") ? document["TenSP"].AsString : string.Empty,
                    LoaiSP = document.Contains("LoaiSP") ? document["LoaiSP"].AsString : string.Empty,
                    GiaSP = document.Contains("GiaSP") ? document["GiaSP"].AsDouble : 0.0,
                    SoLuongTon = document.Contains("SoLuongTon") ? document["SoLuongTon"].AsInt32 : 0,
                    NgayNhapKho = document.Contains("NgayNhapKho") ? document["NgayNhapKho"].ToUniversalTime() : DateTime.MinValue,
                    ThoiGianBaoHanh = document.Contains("ThoiGianBaoHanh") && document["ThoiGianBaoHanh"] != BsonNull.Value
                                      ? document["ThoiGianBaoHanh"].AsInt32
                                      : (int?)null,
                    ThuongHieu = document.Contains("ThuongHieu") ? document["ThuongHieu"].AsString : string.Empty,
                    GiaGoc = document.Contains("GiaGoc") ? document["GiaGoc"].AsDouble : 0.0,
                    MoTa = document.Contains("MoTa") ? document["MoTa"].AsString : string.Empty
                };
            }
            return null;
        }


        public static List<SanPham> DSSanPhamByName(string name)
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            // Get the "SanPham" collection from the CauLong database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("SanPham");
            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Regex("TenSP", new BsonRegularExpression(name, "i"));
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();
            foreach (var doc in documents)
            {
                SanPham sp = new SanPham
                {
                    MaSP = doc.Contains("MaSP") ? doc["MaSP"].AsInt32 : 0,
                    TenSP = doc.Contains("TenSP") ? doc["TenSP"].AsString : string.Empty,
                    LoaiSP = doc.Contains("LoaiSP") ? doc["LoaiSP"].AsString : string.Empty,
                    GiaSP = doc.Contains("GiaSP") ? doc["GiaSP"].AsDouble : 0.0,
                    SoLuongTon = doc.Contains("SoLuongTon") ? doc["SoLuongTon"].AsInt32 : 0,
                    NgayNhapKho = doc.Contains("NgayNhapKho") ? doc["NgayNhapKho"].ToUniversalTime() : DateTime.MinValue,
                    ThoiGianBaoHanh = doc.Contains("ThoiGianBaoHanh") && doc["ThoiGianBaoHanh"] != BsonNull.Value
                                      ? doc["ThoiGianBaoHanh"].AsInt32
                                      : (int?)null,
                    ThuongHieu = doc.Contains("ThuongHieu") ? doc["ThuongHieu"].AsString : string.Empty,
                    GiaGoc = doc.Contains("GiaGoc") ? doc["GiaGoc"].AsDouble : 0.0,
                    MoTa = doc.Contains("MoTa") ? doc["MoTa"].AsString : string.Empty
                };
                dsSanPham.Add(sp);
            }
            return dsSanPham;
        }
    }
}
