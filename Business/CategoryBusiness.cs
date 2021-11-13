using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ShoppingCartNew.Business
{
    class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    class CategoryBusiness
    {
        // Khai báo đối tượng kết nối
        SqlConnection connection;
        // Khai báo đối tượng thực thi các truy vấn
        SqlCommand command;

        // Phương thức lấy chuỗi kết nối từ appsettings.json
        string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionString:MilkTeaDB"];
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select CategoryId, CategoryName from Category", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryID = reader.GetInt32("CategoryId"),
                            CategoryName = reader.GetString("CategoryName")
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

            return categories;
        }

        public int InsertCategory(Category category)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            string sql = "insert into Category(CategoryName) values(@catName)";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@catName", category.CategoryName);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int UpdateCategory(Category category)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            string sql = "update Category set CategoryName = @catName where CategoryId=@catID";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@catName", category.CategoryName);
            command.Parameters.AddWithValue("@catID", category.CategoryID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int DeleteCategory(Category category)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            string sql = "delete from Category where CategoryID = @catID";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@catID", category.CategoryID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
