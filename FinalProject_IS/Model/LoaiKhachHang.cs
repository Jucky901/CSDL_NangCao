using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class LoaiKhachHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaLoaiKhachHang")]
        [BsonRequired]
        public int MaLoaiKhachHang { get; set; }

        [BsonElement("TenLoaiKhachHang")]
        public string TenLoaiKhachHang { get; set; }

        [BsonElement("ChiTieuToiThieu")]
        [BsonRequired]
        public double ChiTieuToiThieu { get; set; }

        [BsonElement("GiamGiaToiDa")]
        [BsonRequired]
        public double GiamGiaToiDa { get; set; }
    }
}
