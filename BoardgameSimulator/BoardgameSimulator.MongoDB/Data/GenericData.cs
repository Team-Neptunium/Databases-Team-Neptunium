using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB.Data
{
    public class GenericData<T> : IGenericData<T>
    {
        private MongoDatabase database;

        public GenericData(MongoDatabase database, string collectionName)
        {
            this.database = database;

            this.Collection = this.database.GetCollection<T>(collectionName);
        }

        public MongoCollection<T> Collection { get; set; }

        public IEnumerable<T> GetAllDataFromCollection()
        {
            return this.Collection.FindAllAs<T>().ToList();
        }
    }
}
