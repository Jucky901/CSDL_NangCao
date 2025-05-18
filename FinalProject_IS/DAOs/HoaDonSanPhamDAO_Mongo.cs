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
    public class HoaDonSanPhamDAO_Mongo
    {
        public static List<HoaDonSanPham> DSHoaDonSanPham()
        {
            List<HoaDonSanPham> dsHoaDonSanPham = new List<HoaDonSanPham>();

            // Get the "HoaDonSanPham" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("HoaDonSanPham");

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                HoaDonSanPham hd = new HoaDonSanPham
                {
                    MaHD = doc.Contains("MaHD") ? doc["MaHD"].AsInt32 : 0,
                    MaKH = doc.Contains("MaKH") ? doc["MaKH"].AsInt32 : 0,
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    NgayGioTao = doc.Contains("NgayGioTao") ? doc["NgayGioTao"].ToUniversalTime() : DateTime.MinValue,
                    TongTien = doc.Contains("TongTien") && doc["TongTien"] != BsonNull.Value
                               ? doc["TongTien"].AsDouble
                               : (double?)null,
                    SanPham = new List<SanPhamHoaDon>()
                };

                // Parse the nested "SanPham" array
                if (doc.Contains("SanPham") && doc["SanPham"].IsBsonArray)
                {
                    foreach (var spDoc in doc["SanPham"].AsBsonArray)
                    {
                        BsonDocument spBson = spDoc.AsBsonDocument;

                        SanPhamHoaDon sp = new SanPhamHoaDon
                        {
                            MaSP = spBson.Contains("MaSP") ? spBson["MaSP"].AsInt32 : 0,
                            TenSP = spBson.Contains("TenSP") ? spBson["TenSP"].AsString : string.Empty,
                            SoLuong = spBson.Contains("SoLuong") ? spBson["SoLuong"].AsInt32 : 0,
                            DonGia = spBson.Contains("GiaBan") ? spBson["GiaBan"].AsDouble : 0.0
                        };

                        hd.SanPham.Add(sp);
                    }
                }

                dsHoaDonSanPham.Add(hd);
            }

            return dsHoaDonSanPham;
        }
    }
}
