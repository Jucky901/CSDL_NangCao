using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class PhieuNhapHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaPhieuNhap")]
        [BsonRequired]
        public int MaPhieuNhap { get; set; }

        [BsonElement("NgayTao")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayTao { get; set; }

        [BsonElement("TinhTrangPhieuNhap")]
        public string TinhTrangPhieuNhap { get; set; }

        [BsonElement("SanPham")]
        public List<SanPhamPhieuNhap> SanPham { get; set; } = new List<SanPhamPhieuNhap>();
    }
}
