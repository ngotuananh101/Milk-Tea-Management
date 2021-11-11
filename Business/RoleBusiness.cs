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
    class RoleBusiness
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

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Role", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            roleId = reader.GetInt32("RoleId"),
                            roleName = reader.GetString("RoleName")
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

            return roles;
        }
    }

    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }

    }
}
