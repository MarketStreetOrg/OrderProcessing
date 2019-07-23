using MongoDB.Driver;
using OrderProcessing.Domain;
using OrderProcessing.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessing.Database.Mongo.Implementation
{
    public class OrderMongoDAO : MongoDAO, IMongoDAO<Order>
    {
        public IMongoCollection<Order> MongoCollection
        {
            get => mongoDB.GetCollection<Order>("orders");
            set => mongoDB.CreateCollection("orders");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string param)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Order model)
        {

            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return MongoCollection.Find("{}").ToList();    
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var result = await MongoCollection.FindAsync("{}");

            return result.ToList();
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Order model)
        {
            MongoCollection.InsertOne(model);          
        }

        public Order Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}