using System.Collections.Generic;
using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB.Data
{
    public interface IGenericData<T>
    {
        MongoCollection<T> Collection { get; set; }

        IEnumerable<T> GetAllDataFromCollection();
    }
}
