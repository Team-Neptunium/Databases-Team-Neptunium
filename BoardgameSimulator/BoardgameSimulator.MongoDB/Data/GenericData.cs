using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB.Data
{
    public class GenericData<T> : IGenericData<T>
    {
        private readonly MongoDatabase database;

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

        public IEnumerable GetAllDataFromCollectionAsJson()
        {
            return this.Collection.FindAll().Select(x => x.ToJson());
        }
    }
}
