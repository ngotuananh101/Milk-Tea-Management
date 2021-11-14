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

        public void InsertEmployee(Employee employee)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("Insert into Employee(EmployeeId, EmployeeName, EmployeeDob, EmployeeEmail, Phone, Address, Gender, ManagerId) values(@EmployeeId, @EmployeeName, @EmployeeDob, @EmployeeEmail, @Phone, @Address, @Gender, @ManagerId)", connection);
            command.Parameters.AddWithValue("@EmployeeId", employee.employeeId);
            command.Parameters.AddWithValue("@EmployeeName", employee.employeeName);
            command.Parameters.AddWithValue("@EmployeeDob", employee.employeeDob);
            command.Parameters.AddWithValue("@EmployeeEmail", employee.employeeEmail);
            command.Parameters.AddWithValue("@Phone", employee.phone);
            command.Parameters.AddWithValue("@Gender", employee.gender);
            command.Parameters.AddWithValue("@Address", employee.address);
            command.Parameters.AddWithValue("@ManagerId", employee.managerId);


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

        public Employee GetEmployeeByUserID(int userId)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("SELECT [EmployeeId],[EmployeeName],[EmployeeDob],[EmployeeEmail],[Phone],[Address],[Gender],[ManagerId],[UserId] FROM [dbo].[Employee] WHERE [UserId]=@UserId",connection);
            command.Parameters.AddWithValue("@UserId", userId);
            Employee employee = null;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            employeeId = reader.GetInt32("EmployeeId").ToString(),
                            employeeName = reader.GetString("EmployeeName"),
                            employeeDob = reader.GetString("EmployeeDob"),
                            employeeEmail = reader.GetString("EmployeeEmail"),
                            phone = reader.GetString("Phone"),
                            address = reader.GetString("Address"),
                            gender = reader.GetBoolean("Gender"),
                            managerId = reader.GetInt32("ManagerId").ToString(),
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

            return employee;
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
