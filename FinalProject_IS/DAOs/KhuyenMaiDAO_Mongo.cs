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
    public class KhuyenMaiDAO_Mongo
    {
        public static List<KhuyenMai> DSKhuyenMai()
        {
            List<KhuyenMai> dsKhuyenMai = new List<KhuyenMai>();

            // Get the "KhuyenMai" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("KhuyenMai");

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                KhuyenMai km = new KhuyenMai
                {
                    MaKM = doc.Contains("MaKM") ? doc["MaKM"].AsInt32 : 0,
                    TenCTKM = doc.Contains("TenCTKM") ? doc["TenCTKM"].AsString : string.Empty,
                    GiaTriKhuyenMai = doc.Contains("GiaTriKhuyenMai") ? doc["GiaTriKhuyenMai"].AsDouble : 0.0,
                    DieuKienKhuyenMai = doc.Contains("DieuKienKhuyenMai") ? doc["DieuKienKhuyenMai"].AsString : string.Empty,
                    NgayBatDau = doc.Contains("NgayBatDau") ? doc["NgayBatDau"].ToUniversalTime() : DateTime.MinValue,
                    NgayKetThuc = doc.Contains("NgayKetThuc") ? doc["NgayKetThuc"].ToUniversalTime() : DateTime.MinValue,
                    SoLuong = doc.Contains("SoLuong") ? doc["SoLuong"].AsInt32 : 0
                };

                dsKhuyenMai.Add(km);
            }

            return dsKhuyenMai;
        }

        public static void InsertKhuyenMai(KhuyenMai khuyenMai)
        {
            var collection = MongoConnection.Database.GetCollection<KhuyenMai>("KhuyenMai");

            try
            {
                // Auto-increment MaKM using the counter
                khuyenMai.MaKM = SequenceDAO.GetNextSequenceValue("KhuyenMai");
                collection.InsertOne(khuyenMai);
                Console.WriteLine("KhuyenMai inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting KhuyenMai: {ex.Message}");
            }
        }

        public static bool DeleteKhuyenMaiByMaKM(int maKM)
        {
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("KhuyenMai");

            var filter = Builders<BsonDocument>.Filter.Eq("MaKM", maKM);

            var result = collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }

        public static bool DeleteKhuyenMaiByMaKM(List<int> maKhuyenMai)
        {
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("KhuyenMai");
            var filter = Builders<BsonDocument>.Filter.In("MaKM", maKhuyenMai);
            var result = collection.DeleteMany(filter);
            return result.DeletedCount > 0;
        }
        public static void GiamSoLuong(int maKM, int amount)
        {
            var col = MongoConnection.Database.GetCollection<KhuyenMai>("KhuyenMai");
            var filter = Builders<KhuyenMai>.Filter.Eq(k => k.MaKM, maKM);
            var update = Builders<KhuyenMai>.Update.Inc(k => k.SoLuong, -amount);
            col.UpdateOne(filter, update);
        }
    }
}
