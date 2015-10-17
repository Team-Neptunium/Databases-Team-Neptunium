using MongoDB.Driver;

namespace BoardgameSimulator.MongoDB.Data
{
    using System.Collections.Generic;

    public interface IGenericData<T>
    {
        MongoCollection<T> Collection { get; set; }

        IEnumerable<T> GetAllDataFromCollection();
    }
}
