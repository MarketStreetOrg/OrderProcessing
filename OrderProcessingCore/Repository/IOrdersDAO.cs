using OrderProcessingCore.DAO.Generic;
using OrderProcessingCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingCore.DAO
{
    public interface IOrdersDAO : IGenericDAO<Order>
    {
        void UpdateOrderItem(string sku, int quantity, string ordernumber);

        void InsertOrderItem(string sku, string Ordernumber ,int Quantity);
       
    }
}
