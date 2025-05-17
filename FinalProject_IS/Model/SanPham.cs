using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinalProject_IS.Model
{
    public class SanPham
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("MaSP")]
        public int MaSP { get; set; }

        [BsonElement("TenSP")]
        public string TenSP { get; set; }

        [BsonElement("LoaiSP")]
        public string LoaiSP { get; set; }

        [BsonElement("GiaBan")]
        public double GiaBan { get; set; }

        [BsonElement("SoLuongTon")]
        public int SoLuongTon { get; set; }

        [BsonElement("NgayNhapKho")]
        public DateTime NgayNhapKho { get; set; }

        [BsonElement("ThoiGianBaoHanh")]
        public int? ThoiGianBaoHanh { get; set; }

        [BsonElement("GiaGoc")]
        public double GiaGoc { get; set; }

        [BsonElement("MoTa")]
        public string MoTa { get; set; }
    }
}
