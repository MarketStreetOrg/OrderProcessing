using OrderProcessing.DAO;
using OrderProcessing.Domain;
using OrderProcessing.Utilities;
using OrderProcessing.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OrderProcessing.Database.Sql.Implementation
{
    public class OrderSqlDao : SqlDAO, ISqlDAO<Order>, IOrdersDAO
    {
        public OrderSqlDao()
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string OrderNumber)
        {
            Con = CreateConnection();

            Query = "DeleteOrder";

            Com.Connection = Con;

            Com.CommandType = CommandType.StoredProcedure;

            Com.CommandText = Query;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@OrderNumber", OrderNumber));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();
        }

        public bool Exists(Order order)
        {
            Con = CreateConnection();

            Query = "select [dbo].OrderExists(@OrderNumber)";

            Com.Connection = Con;
            Com.CommandText = Query;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@OrderNumber", order.OrderNumber));

            return ((int)(Com.ExecuteScalar()) == 1 ? true : false);

        }

        public async Task<List<Order>> GetAllAsync()
        {
            List<Order> orders = new List<Order>();

            Con = CreateConnection();

            Query = "select * from ordersView";

            Com.CommandText = Query;
            Com.Connection = Con;

            DataAdapter.SelectCommand = Com;

            DataTable dataTable = new DataTable();

            DataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Order order = new Order.Builder()
                 .setCustomerNumber(row["customerID"].ToString())
                 .setOrderNumber(row["ordernumber"].ToString())
                 .setDate(Convert.ToDateTime(row["datecreated"].ToString()))
                 .Build();

                var r = await GetItemsAsync(order.OrderNumber);

                r.ForEach(p =>
                {

                    order.Products.Add(p);

                });

                orders.Add(order);
            }

            Com.Dispose();

            Con.Close();

            return orders;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            Con = CreateConnection();

            Query = "select * from ordersView";

            Com.CommandText = Query;
            Com.Connection = Con;

            DataAdapter.SelectCommand = Com;

            DataTable dataTable = new DataTable();

            DataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Order order = new Order.Builder()
                 .setCustomerNumber(row["customerID"].ToString())
                 .setOrderNumber(row["ordernumber"].ToString())
                 .setDate(Convert.ToDateTime(row["datecreated"].ToString()))
                 .Build();

                GetItemsAsync(order.OrderNumber).Result.ForEach(p =>
                {
                    order.Products.Add(p);
                });

                orders.Add(order);

            }

            Com.Dispose();

            Con.Close();

            return orders;
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();

        }

        public Order GetByName(string OrderNumber)
        {
            Order order = null;

            Con = CreateConnection();
            Query = "SelectOrder";
            Com.CommandText = Query;
            Com.Connection = Con;
            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Add(new SqlParameter("@OrderNumber", OrderNumber));

            DataAdapter.SelectCommand = Com;

            DataTable dataTable = new DataTable();

            DataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                order = new Order.Builder()
                  .setCustomerNumber(row["customerID"].ToString())
                  .setOrderNumber(row["ordernumber"].ToString())
                  .setDate(Convert.ToDateTime(row["datecreated"].ToString()))
                  .Build();

                GetItemsAsync(OrderNumber).Result.ForEach(i => order.Products.Add(i));

            }

            return order;
        }

        public List<Order> GetByQuery(string Query)
        {
            throw new NotImplementedException();
        }

        private async Task<List<Product>> GetItemsAsync(string OrderNumber)
        {
            List<Product> items = new List<Product>();

            Con = CreateConnection();

            Query = "selectOrdersWithItems";

            Com.CommandText = Query;
            Com.Connection = Con;
            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@orderNumber", OrderNumber));

            DataAdapter.SelectCommand = Com;

            DataTable dataTable = new DataTable();

            DataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                string sku = row["sku"].ToString();

                Product product = new Product.Builder()
                   .SetSKU(sku)
                   .Build();

                int quantity = Convert.ToInt32(row["quantity"].ToString());

                product.Quantity = quantity;

                items.Add(product);
            }

            Com.Dispose();

            Con.Close();

            return items;
        }

        /*
         * Add Item to order
         *  
         */
        public void InsertOrderItem(string Sku, string OrderNumber, int Quantity)
        {

            Con = CreateConnection();

            Query = "insert into order_product (ordernumber,sku,quantity) " +
                "values(@ordernumber,@sku,@quantity)";

            Com.CommandText = Query;
            Com.Connection = Con;
            Com.CommandType = CommandType.Text;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@ordernumber", OrderNumber));
            Com.Parameters.Add(new SqlParameter("@sku", Sku));
            Com.Parameters.Add(new SqlParameter("@quantity", Quantity));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();
        }

        //Save Order
        public void Save(Order order)
        {
            if (order.Products == null || order.Products.Count == 0) throw new EmptyOrderException();

            Con = CreateConnection();

            Query = "SaveOrder";

            Com.CommandText = Query;
            Com.Connection = Con;
            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerNumber));

            string OrderNumber = Convert.ToString(Com.ExecuteScalar());

            order.OrderNumber = OrderNumber;

            Com.Dispose();

            Con.Close();

            order.Products.ToList().ForEach(p =>
            {
                InsertOrderItem(p.SKU, order.OrderNumber, p.Quantity);
            });

        }

        public Order Update(Order order)
        {

            //do some checks on items before updating
            Con = CreateConnection();

            Query = "update Orders " +
                "set CustomerID=@CustomerID," +
                "DateCreated=@DateCreated," +
                "Status=@Status";

            Com.CommandText = Query;
            Com.Connection = Con;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerNumber));
            Com.Parameters.Add(new SqlParameter("@DateCreated", order.DateCreated));
            Com.Parameters.Add(new SqlParameter("@Status", order.OrderStatus));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();

            order.Products.ToList().ForEach(p =>
            {
                UpdateOrderItem(p.SKU, p.Quantity, order.OrderNumber);

            });

            return order;
        }

        public void UpdateOrderItem(string sku, int quantity, string ordernumber)
        {
            Con = CreateConnection();

            Query = "update order_product " +
                "set ordernumber=@ordernumber," +
                "sku=@sku," +
                "quantity=@quantity where sku=@sku and ordernumber=@ordernumber";

            Com.CommandText = Query;
            Com.Connection = Con;

            Com.Parameters.Clear();

            Com.Parameters.Add(new SqlParameter("@ordernumber", ordernumber));
            Com.Parameters.Add(new SqlParameter("@Sku", sku));
            Com.Parameters.Add(new SqlParameter("@quantity", quantity));

            Com.ExecuteNonQuery();

            Com.Dispose();

            Con.Close();
        }

    }
}