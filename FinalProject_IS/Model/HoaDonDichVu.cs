using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class HoaDonDichVu
    {
        public HoaDonDichVu()
        {
            ChiTiet = new List<ChiTietDichVu>();
        }
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaHDDV")]
        [BsonRequired]
        public int MaHDDV { get; set; }

        [BsonElement("NgayGioTao")]
        [BsonRequired]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayGioTao { get; set; }

        [BsonElement("MaKH")]
        [BsonRequired]
        public int MaKH { get; set; }

        [BsonElement("SoDienThoai")]
        [BsonIgnoreIfNull]
        public string SoDienThoai { get; set; }

        [BsonElement("MaNV")]
        [BsonRequired]
        public int MaNV { get; set; }

        [BsonElement("TenVot")]
        [BsonRequired]
        public string TenVot { get; set; }

        [BsonElement("LoaiDay")]
        [BsonRequired]
        public string LoaiDay { get; set; }

        [BsonElement("NgayGioLayVot")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonIgnoreIfNull]
        public DateTime? NgayGioLayVot { get; set; }

        [BsonElement("SoKG")]
        [BsonRequired]
        public double SoKG { get; set; }

        [BsonElement("ThanhTien")]
        [BsonIgnoreIfNull]
        public double? ThanhTien { get; set; }

        [BsonElement("LoaiPhieu")]
        [BsonRequired]
        public string LoaiPhieu { get; set; }
        [BsonElement("IsThanhToan")]
        public bool IsThanhToan { get; set; }

        [BsonElement("ChiTiet")]
        public List<ChiTietDichVu> ChiTiet { get; set; }
    }
}
