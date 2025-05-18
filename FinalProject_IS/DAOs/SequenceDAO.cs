using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinalProject_IS.DAOs
{
    public class SequenceDAO
    {
        public static int GetNextSequenceValue(string sequenceName)
        {
            var counterCollection = MongoConnection.Database.GetCollection<BsonDocument>("counters");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", sequenceName);
            var update = Builders<BsonDocument>.Update.Inc("seq", 1);
            var options = new FindOneAndUpdateOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = true
            };

            var result = counterCollection.FindOneAndUpdate(filter, update, options);
            return result["seq"].AsInt32;
        }
    }
}
