using OrderProcessing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderProcessing.Database.Sql.Implementation
{
    public class OrderSqlDao : SqlDAO, ISqlDAO<Order>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}