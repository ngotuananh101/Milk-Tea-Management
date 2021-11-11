using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTeaManagement.Business
{
    class AccountBusiness
    {
        SqlConnection connection;
        SqlCommand command;

        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            return config["ConnectionStrings:MilkTeaDB"];
        }

        public List<Account> GetAccount(string username, string password)
        {
            List<Account> accounts = new List<Account>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Account where Username = '" + username + "' and Password = '" + password + "'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        accounts.Add(new Account
                        {
                            userId = reader.GetString("UserId"),
                            userName = reader.GetString("Username"),
                            passWord = reader.GetString("Password"),
                            roleId = reader.GetInt32("RoleId")
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

            return accounts;
        }
    }

    public class Account
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public int roleId { get; set; }
    }
}
