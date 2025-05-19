using FinalProject_IS.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_IS.DAOs
{
    internal class KhuyenMaiDaDungDAO
    {
        private readonly IMongoCollection<KhuyenMaiDaDung> _collection;

        public KhuyenMaiDaDungDAO(IMongoDatabase db)
        {
            _collection = db.GetCollection<KhuyenMaiDaDung>("KhuyenMaiDaDung");
        }

        public async Task<bool> DaSuDungAsync(int maKM, string sdt)
        {
            var filter = Builders<KhuyenMaiDaDung>.Filter.Eq("MaKM", maKM) &
                         Builders<KhuyenMaiDaDung>.Filter.Eq("SDT", sdt);
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task ThemKhuyenMaiDaDungAsync(KhuyenMaiDaDung km)
        {
            await _collection.InsertOneAsync(km);
        }
        public class KhuyenMaiDAO_Mongo
        {
            public static List<KhuyenMai> DSKhuyenMai()
            {
                var collection = MongoConnection.Database.GetCollection<KhuyenMai>("KhuyenMai");
                return collection.Find(Builders<KhuyenMai>.Filter.Empty).ToList();
            }

            public static void InsertKhuyenMai(KhuyenMai km)
            {
                var collection = MongoConnection.Database.GetCollection<KhuyenMai>("KhuyenMai");
                km.MaKM = SequenceDAO.GetNextSequenceValue("KhuyenMai");
                collection.InsertOne(km);
            }
        }
       
    }

}
