using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class KhachHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaKH")]
        [BsonRequired]
        public int MaKH { get; set; }

        [BsonElement("HoTen")]
        public string HoTen { get; set; }

        [BsonElement("SoDienThoai")]
        public string SoDienThoai { get; set; }

        [BsonElement("TongChiTieu")]
        [BsonRequired]
        public double TongChiTieu { get; set; }

        [BsonElement("NgayBatDau")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime NgayBatDau { get; set; }

        [BsonElement("MaLoaiKH")]
        public int MaLoaiKH { get; set; }
    }
}
