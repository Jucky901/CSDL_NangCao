using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace FinalProject_IS.DAOs
{
    public class MongoConnection
    {
        public static readonly string mongoConStr = Properties.Settings.Default.mongoConStr;

        private static readonly MongoClient client = new MongoClient(mongoConStr);

        // Expose the MongoDatabase instance
        public static IMongoDatabase Database => client.GetDatabase("CauLong");
    }
}
