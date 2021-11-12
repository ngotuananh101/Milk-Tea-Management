﻿using Microsoft.Data.SqlClient;
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
    class OrdersBusiness
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

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Orders", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            orderId = reader.GetInt32("OrderId"),
                            employeeId = reader.GetString("EmployeeId"),
                            total = reader.GetDecimal("Total"),
                            date = reader.GetDateTime("DateCreate")
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

            return orders;
        }
    }

    public class Order
    {
        public int orderId { get; set; }
        public string employeeId { get; set; }
        public decimal total { get; set; }
        public DateTime date { get; set; }
    }
}