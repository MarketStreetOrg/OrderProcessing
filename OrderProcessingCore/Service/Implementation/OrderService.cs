using System.Collections.Generic;
using OrderProcessingCore.DAO;
using OrderProcessingCore.DAO.Generic;
using OrderProcessingCore.Database.Mongo.Implementation;
using OrderProcessingCore.Database.Sql.Implementation;
using OrderProcessingCore.Domain;

namespace OrderProcessingCore.Service
{
    public class OrderService : IOrderService
    {
        IOrdersDAO orderDao;

        public OrderService(IOrdersDAO ordersDAO)
        {
            orderDao = ordersDAO;
        }

        public OrderService()
        {
           
        }

        public Order GetSingle(string OrderNumber)
        {
            return orderDao.GetByName(OrderNumber);
        }

        public Order GetSingle(Order entity)
        {
            return (entity.OrderNumber!=null)?orderDao.GetByName(entity.OrderNumber):null;
        }

        public List<Order> GetAll()
        {
            return orderDao.GetAllAsync().Result;
        }

        public void Save(Order order)
        {
            orderDao.Save(order);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string OrderNumber)=>orderDao.Delete(OrderNumber);
        
        public Order Update(Order order)
        {
            return orderDao.Update(order);
        }

        public Order GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(Order order)
        {
            return orderDao.Exists(order);
        }
    }
}