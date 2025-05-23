﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_IS.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinalProject_IS.DAOs
{
    public class NhanVienDAO_Mongo
    {
        private readonly IMongoCollection<NhanVien> _col;

        public NhanVienDAO_Mongo(IMongoDatabase database)
        {
            _col = database.GetCollection<NhanVien>("NhanVien");
        }
        public static List<NhanVien> DSNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            // Get the "NhanVien" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("NhanVien");

            // Fetch the top 100 documents, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).Limit(100).ToList();

            foreach (var doc in documents)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    HoTen = doc.Contains("HoTen") ? doc["HoTen"].AsString : string.Empty,
                    NgaySinh = doc.Contains("NgaySinh") ? doc["NgaySinh"].ToUniversalTime() : DateTime.MinValue,
                    GioiTinh = doc.Contains("GioiTinh") ? doc["GioiTinh"].AsString : string.Empty,
                    Email = doc.Contains("Email") ? doc["Email"].AsString : string.Empty,
                    TenChucVu = doc.Contains("TenChucVu") ? doc["TenChucVu"].AsString : string.Empty,
                    LuongCoBan = doc.Contains("LuongCoBan") ? doc["LuongCoBan"].AsDouble : 0.0
                };

                dsNhanVien.Add(nv);
            }

            return dsNhanVien;
        }

        public static int GetMaNVByName(string name)
        {
            // Get the "NhanVien" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("NhanVien");
            // Create a filter to find the document with the specified name
            var filter = Builders<BsonDocument>.Filter.Eq("HoTen", name);
            // Find the document
            var document = collection.Find(filter).FirstOrDefault();
            // Return the MaNV if found, otherwise return null
            return document != null ? document["MaNV"].AsInt32 : 0;
        }
        public async Task<int?> TimMaNVTheoTenAsync(string hoTen)
        {
            var filter = Builders<NhanVien>.Filter.Eq(nv => nv.HoTen, hoTen);
            var nv = await _col.Find(filter)
                               .Project(n => new { n.MaNV })
                               .FirstOrDefaultAsync();
            return nv == null ? (int?)null : nv.MaNV;
        }

        public static NhanVien KiemTraDangNhap(string email, int manv)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CauLong");
            var collection = database.GetCollection<NhanVien>("NhanVien");

            var filter = Builders<NhanVien>.Filter.Eq(nv => nv.Email, email) &
                         Builders<NhanVien>.Filter.Eq(nv => nv.MaNV, manv);

            var nhanVien = collection.Find(filter).FirstOrDefault();

            return nhanVien;
        }

        public static List<NhanVien> DSNhanVienByName(string name)
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            // Get the "NhanVien" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("NhanVien");
            // Fetch the documents that match the name, excluding the "_id" field
            var filter = Builders<BsonDocument>.Filter.Regex("HoTen", new BsonRegularExpression(name, "i"));
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var documents = collection.Find(filter).Project(projection).ToList();
            foreach (var doc in documents)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    HoTen = doc.Contains("HoTen") ? doc["HoTen"].AsString : string.Empty,
                    NgaySinh = doc.Contains("NgaySinh") ? doc["NgaySinh"].ToUniversalTime() : DateTime.MinValue,
                    GioiTinh = doc.Contains("GioiTinh") ? doc["GioiTinh"].AsString : string.Empty,
                    Email = doc.Contains("Email") ? doc["Email"].AsString : string.Empty,
                    TenChucVu = doc.Contains("TenChucVu") ? doc["TenChucVu"].AsString : string.Empty,
                    LuongCoBan = doc.Contains("LuongCoBan") ? doc["LuongCoBan"].AsDouble : 0.0
                };
                dsNhanVien.Add(nv);
            }
            return dsNhanVien;
        }

        public static List<NhanVien> DSNhanVienOrderByName()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            // Get the "NhanVien" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("NhanVien");
            // Fetch the documents, excluding the "_id" field, and order by HoTen
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var sort = Builders<BsonDocument>.Sort.Ascending("HoTen");
            var documents = collection.Find(filter).Project(projection).Sort(sort).ToList();
            foreach (var doc in documents)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    HoTen = doc.Contains("HoTen") ? doc["HoTen"].AsString : string.Empty,
                    NgaySinh = doc.Contains("NgaySinh") ? doc["NgaySinh"].ToUniversalTime() : DateTime.MinValue,
                    GioiTinh = doc.Contains("GioiTinh") ? doc["GioiTinh"].AsString : string.Empty,
                    Email = doc.Contains("Email") ? doc["Email"].AsString : string.Empty,
                    TenChucVu = doc.Contains("TenChucVu") ? doc["TenChucVu"].AsString : string.Empty,
                    LuongCoBan = doc.Contains("LuongCoBan") ? doc["LuongCoBan"].AsDouble : 0.0
                };
                dsNhanVien.Add(nv);
            }
            return dsNhanVien;
        }


        public static List<NhanVien> DSNhanVienOrderBySDT()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            // Get the "NhanVien" collection from the database
            var collection = MongoConnection.Database.GetCollection<BsonDocument>("NhanVien");
            // Fetch the documents, excluding the "_id" field, and order by SDT
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var sort = Builders<BsonDocument>.Sort.Ascending("SDT");
            var documents = collection.Find(filter).Project(projection).Sort(sort).ToList();
            foreach (var doc in documents)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = doc.Contains("MaNV") ? doc["MaNV"].AsInt32 : 0,
                    HoTen = doc.Contains("HoTen") ? doc["HoTen"].AsString : string.Empty,
                    NgaySinh = doc.Contains("NgaySinh") ? doc["NgaySinh"].ToUniversalTime() : DateTime.MinValue,
                    GioiTinh = doc.Contains("GioiTinh") ? doc["GioiTinh"].AsString : string.Empty,
                    Email = doc.Contains("Email") ? doc["Email"].AsString : string.Empty,
                    TenChucVu = doc.Contains("TenChucVu") ? doc["TenChucVu"].AsString : string.Empty,
                    LuongCoBan = doc.Contains("LuongCoBan") ? doc["LuongCoBan"].AsDouble : 0.0
                };
                dsNhanVien.Add(nv);
            }
            return dsNhanVien;
        }
    }
}
