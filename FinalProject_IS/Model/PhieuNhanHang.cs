using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class PhieuNhanHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaPhieuNhan")]
        [BsonRequired]
        public int MaPhieuNhan { get; set; }

        [BsonElement("NgayNhan")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayNhan { get; set; }

        [BsonElement("SanPham")]
        public List<SanPhamPhieuNhan> SanPham { get; set; } = new List<SanPhamPhieuNhan>();
    }
}
