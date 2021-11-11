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
    class EmployeeBusiness
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

        public List<Employee> GetEmployeeById(string employeeid)
        {
            List<Employee> employees = new List<Employee>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Employee where EmployeeId = '" + employeeid + "'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            employeeId = reader.GetString("EmployeeId"),
                            employeeName = reader.GetString("EmployeeName"),
                            employeeDob = reader.GetString("EmployeeDob"),
                            employeeEmail = reader.GetString("EmployeeEmail"),
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

            return employees;
        }

        public string GetManagerId(string employeeid)
        {
            String managerId = "";
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select ManagerId from Employee where EmployeeId = '" + employeeid + "'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        managerId = reader.GetString("ManagerId");
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

            return managerId;
        }

    }
    public class Employee
    {
        public string employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeDob { get; set; }
        public string employeeEmail { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public bool gender { get; set; }
        public string managerId { get; set; }
        public string userId { get; set; }
    }
}
