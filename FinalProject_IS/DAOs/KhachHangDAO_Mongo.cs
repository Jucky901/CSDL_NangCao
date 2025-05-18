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
        public KhachHangDAO_Mongo(IMongoDatabase database)
        {
            _collection = database.GetCollection<KhachHang>("KhachHang");
        }
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

        public static KhachHang GetKhachHangBySDT(string sdt)
        {
            // Get the "KhachHang" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("KhachHang");
            // Fetch the document with the specified SoDienThoai
            var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", sdt);
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var document = collection.Find(filter).Project(projection).FirstOrDefault();
            if (document != null)
            {
                KhachHang kh = new KhachHang
                {
                    MaKH = document.Contains("MaKH") ? document["MaKH"].AsInt32 : 0,
                    HoTen = document.Contains("HoTen") ? document["HoTen"].AsString : string.Empty,
                    SoDienThoai = document.Contains("SoDienThoai") ? document["SoDienThoai"].AsString : string.Empty,
                    TongChiTieu = document.Contains("TongChiTieu") ? document["TongChiTieu"].AsDouble : 0.0,
                    NgayBatDau = document.Contains("NgayBatDau") ? document["NgayBatDau"].ToUniversalTime() : DateTime.MinValue,
                    MaLoaiKH = document.Contains("MaLoaiKH") ? document["MaLoaiKH"].AsInt32 : 0
                };
                return kh;
            }
            return null;
        }

        public static bool InsertKhachHang(KhachHang kh)
        {
            var collection = MongoConnection.Database.GetCollection<KhachHang>("KhachHang");

            try
            {
                // Insert the KhachHang object into the collection
                kh.MaKH = SequenceDAO.GetNextSequenceValue("KhachHang");
                collection.InsertOne(kh);
                return true;
            }
            catch (MongoWriteException ex)
            {
                // Handle the exception if the document already exists
                Console.WriteLine($"Error inserting document: {ex.Message}");
                return false;
            }
        }
        private readonly IMongoCollection<KhachHang> _collection;
        public async Task<int?> TimMaKHTheoSDT(string sdt)
        {
            var filter = Builders<KhachHang>.Filter.Eq("SoDienThoai", sdt);
            var kh = await _collection.Find(filter).FirstOrDefaultAsync();
            return kh?.MaKH;
        }
    }
}
