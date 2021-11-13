using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;


namespace MenuCRUD
{
    class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Origin { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }

    }

    class ProductBusiness
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

        public List<Product> GetProducts()
        {
            List<Product> categories = new List<Product>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Product", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        // Doc tung record vao categories
                        categories.Add(new Product
                        {
                            ProductId = reader.GetString("ProductId"),
                            ProductName = reader.GetString("ProductName"),
                            Quantity = reader.GetInt32("Quantity"),
                            Price = reader.GetInt32("Price"),
                            Origin = reader.GetString("Origin"),
                            CategoryId = reader.GetInt32("CategoryId"),
                            Image = reader.GetString("Image")
                        });
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

        public void UpdateProduct(Product product)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("Update Product set  ProductName ='" + product.ProductName + "', " +
                "Quantity = '" + product.Quantity + "',Price = '" + product.Price + "'," +
                " Origin = '" + product.Origin + "', CategoryId = '" + product.CategoryId + "'" +
                " where ProductId = '" + product.ProductId + "'", connection);


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


        public void DeleteProduct(Product product)
        {
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("delete from Product where ProductId= '" + product.ProductId + "'", connection);
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
        public List<Product> GetProductsWithCatID(Product product)
        {
            List<Product> products = new List<Product>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Product where CategoryId = @catID", connection);
            command.Parameters.AddWithValue("@catID", product.CategoryId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetString("ProductId"),
                            ProductName = reader.GetString("ProductName"),
                            Price = reader.GetInt32("Price"),
                            CategoryId = reader.GetInt32
                                ("CategoryId"),
                            Image = reader.GetString("Image")
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

            return products;
        }

    }
}
