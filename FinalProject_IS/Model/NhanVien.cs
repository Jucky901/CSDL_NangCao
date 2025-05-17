using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class NhanVien
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaNV")]
        [BsonRequired]
        public int MaNV { get; set; }

        [BsonElement("HoTen")]
        [BsonRepresentation(BsonType.String)]
        public string HoTen { get; set; } // Removed [BsonMaxLength(100)]

        [BsonElement("NgaySinh")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgaySinh { get; set; }

        [BsonElement("GioiTinh")]
        [BsonRepresentation(BsonType.String)]
        public string GioiTinh { get; set; } // Removed [BsonMaxLength(10)]

        [BsonElement("Email")]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; } // Removed [BsonMaxLength(100)]

        [BsonElement("TenChucVu")]
        [BsonRepresentation(BsonType.String)]
        public string TenChucVu { get; set; }

        [BsonElement("LuongCoBan")]
        [BsonRepresentation(BsonType.Double)]
        public double LuongCoBan { get; set; }
    }
}