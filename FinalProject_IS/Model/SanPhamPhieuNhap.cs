using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject_IS.Model
{
    public class SanPhamPhieuNhap
    {
        [BsonElement("MaSP")]
        [BsonRequired]
        public int MaSP { get; set; }

        [BsonElement("TenSP")]
        [BsonRequired]
        public string TenSP { get; set; }

        [BsonElement("SoLuongNhap")]
        [BsonRequired]
        public int SoLuongNhap { get; set; }

        [BsonElement("SoLuongThieu")]
        [BsonRequired]
        public int SoLuongThieu { get; set; }
    }
}
