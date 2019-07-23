using MongoDB.Driver;
using OrderProcessing.DAO.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Database.Mongo
{
    public interface IMongoDAO<T> : IGenericDAO<T>
    {
        IMongoCollection<T> MongoCollection { get; set; }
    }
}
