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
    public class HoaDonDichVuDAO_Mongo
    {
        public static List<HoaDonDichVu> DSHoaDonDichVu()
        {
            List<HoaDonDichVu> dsHoaDonDichVu = new List<HoaDonDichVu>();

            // Get the "HoaDonDichVu" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("HoaDonDichVu");

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                HoaDonDichVu hddv = new HoaDonDichVu
                {
                    MaHDDV = doc.Contains("MaHDDV") ? doc["MaHDDV"].AsInt32 : 0,
                    NgayGioTao = doc.Contains("NgayGioTao") ? doc["NgayGioTao"].ToUniversalTime() : DateTime.MinValue,
                    MaKH = doc.Contains("MaKH") ? doc["MaKH"].AsInt32 : 0,
                    SoDienThoai = doc.Contains("SoDienThoai") ? doc["SoDienThoai"].AsString : string.Empty,
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    TenVot = doc.Contains("TenVot") ? doc["TenVot"].AsString : string.Empty,
                    LoaiDay = doc.Contains("LoaiDay") ? doc["LoaiDay"].AsString : string.Empty,
                    NgayGioLayVot = doc.Contains("NgayGioLayVot") && doc["NgayGioLayVot"] != BsonNull.Value
                                    ? doc["NgayGioLayVot"].ToUniversalTime()
                                    : (DateTime?)null,
                    SoKG = doc.Contains("SoKG") ? doc["SoKG"].AsDouble : 0.0,
                    ThanhTien = doc.Contains("ThanhTien") && doc["ThanhTien"] != BsonNull.Value
                                ? doc["ThanhTien"].AsDouble
                                : (double?)null,
                    LoaiPhieu = doc.Contains("LoaiPhieu") ? doc["LoaiPhieu"].AsString : string.Empty
                };

                dsHoaDonDichVu.Add(hddv);
            }

            return dsHoaDonDichVu;
        }

        public static bool InsertHoaDonDichVu(HoaDonDichVu hddv)
        {
            try
            {
                var collection = MongoConnection.Database.GetCollection<HoaDonDichVu>("HoaDonDichVu");
                collection.InsertOne(hddv);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting HoaDonDichVu: {ex.Message}");
                return false;
            }
        }
    }
}
