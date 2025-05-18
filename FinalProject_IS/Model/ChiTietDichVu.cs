using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_IS.Model
{
    public class ChiTietDichVu
    {
        [BsonElement("TenVot")]
        public string TenVot { get; set; }

        [BsonElement("LoaiDay")]
        public string LoaiDay { get; set; }

        [BsonElement("SoKG")]
        public double SoKG { get; set; }

        [BsonElement("ThanhTien")]
        public double ThanhTien { get; set; }
    }
}
