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
    class ManagerBusiness
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

        public List<Manager> GetManagerById(string managerid)
        {
            List<Manager> managers = new List<Manager>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Manager where ManagerId = '" + managerid + "'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        managers.Add(new Manager
                        {
                            managerId = reader.GetString("ManagerId"),
                            managerName = reader.GetString("ManagerName"),
                            managerDob = reader.GetString("ManagerDob"),
                            managerEmail = reader.GetString("ManagerEmail"),
                            phone = reader.GetString("Phone"),
                            address = reader.GetString("Address"),
                            gender = reader.GetBoolean("Gender"),
                            userId = reader.GetString("UserId")
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

            return managers;
        }
        public Manager GetManagerByUserID(int userId)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("SELECT [ManagerId],[ManagerName],[ManagerDob],[ManagerEmail],[Phone],[Address],[Gender],[UserId] FROM [dbo].[Manager] WHERE [UserId]=@UserId", connection);
            command.Parameters.AddWithValue("@UserId", userId);
            Manager manager = null;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        manager = new Manager
                        {
                            managerId = reader.GetInt32("ManagerId").ToString(),
                            managerName = reader.GetString("ManagerName"),
                            managerDob = reader.GetString("ManagerDob"),
                            managerEmail = reader.GetString("ManagerEmail"),
                            phone = reader.GetString("Phone"),
                            address = reader.GetString("Address"),
                            gender = reader.GetBoolean("Gender"),
                            userId = reader.GetInt32("UserId").ToString()
                        };
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

            return manager;
        }

    }

    public class Manager
    {
        public string managerId { get; set; }
        public string managerName { get; set; }
        public string managerDob { get; set; }
        public string managerEmail { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public bool gender { get; set; }
        public string userId { get; set; }
    }
}
