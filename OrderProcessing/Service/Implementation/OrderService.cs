using System.Collections.Generic;
using OrderProcessing.DAO.Generic;
using OrderProcessing.Database.Sql.Implementation;
using OrderProcessing.Domain;

namespace OrderProcessing.Service
{
    public class OrderService : IOrderService
    {
        IGenericDAO<Order> orderDao = null;

        public OrderService(IGenericDAO<Order> genericDAO)
        {
            orderDao = genericDAO;
        }

        public OrderService()
        {
            orderDao = new OrderSqlDao();
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