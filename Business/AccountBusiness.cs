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

        public List<Account> GetAccounts()
        {
            List<Account> categories = new List<Account>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Account", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        // Doc tung record vao categories
                        categories.Add(new Account { userName = reader.GetString("Username"), passWord = reader.GetString("Password"), roleId = reader.GetInt32("RoleId"), userId = reader.GetString("UserId") });
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return categories;
        }

        public void InsertAccount(Account account)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("Insert into Account(Username, Password, RoleId) values(@Username, @Password, @RoleId)", connection);
            command.Parameters.AddWithValue("@Username", account.userName);
            command.Parameters.AddWithValue("@Password", account.passWord);
            command.Parameters.AddWithValue("@RoleId", account.roleId);
            // command.Parameters.AddWithValue("@UserId", account.userId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteAccount(Account account)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("delete from Account where UserId= '" + account.userId + "'", connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("The data has been deleted");

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateAccount(Account account)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("Update Account set Username = '" + account.userName + "', Password ='" + account.passWord + "', RoleId = '" + account.roleId + "' where UserId = '" + account.userId + "'", connection);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Data has been updated!");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
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
