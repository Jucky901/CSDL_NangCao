using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalProject_IS.Model
{
    public class SanPhamPhieuNhan
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

        [BsonElement("DonGiaNhap")]
        [BsonRequired]
        public double DonGiaNhap { get; set; }

        [BsonElement("ThuongHieu")]
        public string ThuongHieu { get; set; }

        [BsonElement("ThoiGianBaoHanh")]
        public int ThoiGianBaoHanh { get; set; }

        [BsonElement("MoTa")]
        public string MoTa { get; set; }

        [BsonElement("TongTien")]
        [BsonRequired]
        public double TongTien { get; set; }
    }
}
