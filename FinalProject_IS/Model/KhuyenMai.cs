using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class KhuyenMai
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaKM")]
        [BsonRequired]
        public int MaKM { get; set; }

        [BsonElement("TenCTKM")]
        public string TenCTKM { get; set; }

        [BsonElement("GiaTriKhuyenMai")]
        [BsonRequired]
        public double GiaTriKhuyenMai { get; set; }

        [BsonElement("DieuKienKhuyenMai")]
        public string DieuKienKhuyenMai { get; set; }

        [BsonElement("NgayBatDau")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayBatDau { get; set; }

        [BsonElement("NgayKetThuc")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayKetThuc { get; set; }

        [BsonElement("SoLuong")]
        [BsonRequired]
        public int SoLuong { get; set; }
    }
}
