using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject_IS.Model
{
    public class SanPhamHoaDon
    {
        [BsonElement("MaSP")]
        [BsonRequired]
        public int MaSP { get; set; }

        [BsonElement("TenSP")]
        [BsonRequired]
        public string TenSP { get; set; }

        [BsonElement("SoLuong")]
        [BsonRequired]
        public int SoLuong { get; set; }

        [BsonElement("DonGia")]
        [BsonRequired]
        public double DonGia { get; set; }
    }
}
