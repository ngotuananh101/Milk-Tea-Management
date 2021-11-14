using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaManagement.Business
{
    class OrdersDetailBusiness
    {
        SqlConnection connection;
        SqlCommand command;

        string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:MilkTeaDB"];
        }

        public List<OrdersDetail> GetOrdersDetailsById(int orderid)
        {
            List<OrdersDetail> ordersDetails = new List<OrdersDetail>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from OrdersDetail where OrderId = " + orderid, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        ordersDetails.Add(new OrdersDetail
                        {
                            productName = reader.GetString("ProductName"),
                            quantity = reader.GetInt32("Quantity"),
                            price = reader.GetDecimal("Price")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ordersDetails;
        }
        public void InsertOrderDetail(OrdersDetail order)
        {
            try
            {
                connection = new SqlConnection(GetConnectionString());
                command = new SqlCommand(
                    "INSERT INTO [dbo].[OrdersDetail] ([OrderId],[ProductName],[Quantity],[Price]) VALUES ('"+order.orderId+"','"+order.productName+"','"+order.quantity+"','"+order.price+"')", connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public class OrdersDetail
    {
        public int orderId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

    }
}
