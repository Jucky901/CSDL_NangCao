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
    public class KhachHangDAO_Mongo
    {
        public static List<KhachHang> DSKhachHang()
        {
            List<KhachHang> dsKhachHang = new List<KhachHang>();

            // Get the "KhachHang" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("KhachHang");

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                KhachHang kh = new KhachHang
                {
                    MaKH = doc.Contains("MaKH") ? doc["MaKH"].AsInt32 : 0,
                    HoTen = doc.Contains("HoTen") ? doc["HoTen"].AsString : string.Empty,
                    SoDienThoai = doc.Contains("SoDienThoai") ? doc["SoDienThoai"].AsString : string.Empty,
                    TongChiTieu = doc.Contains("TongChiTieu") ? doc["TongChiTieu"].AsDouble : 0.0,
                    NgayBatDau = doc.Contains("NgayBatDau") ? doc["NgayBatDau"].ToUniversalTime() : DateTime.MinValue,
                    MaLoaiKH = doc.Contains("MaLoaiKH") ? doc["MaLoaiKH"].AsInt32 : 0
                };

                dsKhachHang.Add(kh);
            }

            return dsKhachHang;
        }
    }
}
