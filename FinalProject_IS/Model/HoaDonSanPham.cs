using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class HoaDonSanPham
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaHD")]
        [BsonRequired]
        public int MaHD { get; set; }

        [BsonElement("MaKH")]
        [BsonRequired]
        public int MaKH { get; set; }

        [BsonElement("MaNV")]
        [BsonRequired]
        public int MaNV { get; set; }

        [BsonElement("NgayGioTao")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayGioTao { get; set; }

        [BsonElement("TongTien")]
        [BsonIgnoreIfNull]
        public double? TongTien { get; set; }

        [BsonElement("SanPham")]
        [BsonRequired]
        public List<SanPhamHoaDon> SanPham { get; set; } = new List<SanPhamHoaDon>();
    }
}
