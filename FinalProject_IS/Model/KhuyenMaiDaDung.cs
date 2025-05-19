using FinalProject_IS.DAOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.Model
{
    internal class KhuyenMaiDaDung
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaKM")]
        public int MaKM { get; set; }

        [BsonElement("MaKH")]
        public int MaKH { get; set; }

        [BsonElement("SDT")]
        public string SDT { get; set; } = string.Empty;

        [BsonElement("NgaySuDung")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgaySuDung { get; set; }

        [BsonElement("SoTienGiam")]
        public double SoTienGiam { get; set; }
    }
}
