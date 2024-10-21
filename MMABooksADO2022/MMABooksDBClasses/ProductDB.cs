using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM products "
                + "WHERE ProductCode = @ProductCode";
            //Is it a good idea to put "SELECT * FROM products" here?  It's way less to type.
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = (string)prodReader["ProductCode"];
                    product.Description = (string)prodReader["Description"];
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    prodReader.Close();
                    return product;
                }
                else
                {
                    prodReader.Close();
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public static List<Product> GetList()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT * FROM products";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductCode = reader["ProductCode"].ToString();
                    p.Description = reader["Description"].ToString();
                    p.UnitPrice = (decimal)reader["UnitPrice"];
                    p.OnHandQuantity = (int)reader["OnHandQuantity"];
                    products.Add(p);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }
        public static bool AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            string selectStatement
                = "SELECT * "
                + "FROM products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            try
            {
                connection.Open();
                MySqlDataReader prodReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    prodReader.Close();
                    return false;
                }
                prodReader.Close();
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement
                = "UPDATE products SET "
                + "Description = @NewDescription, "
                + "UnitPrice = @NewUnitPrice, "
                + "OnHandQuantity = @NewOnHandQuantity "
                + "WHERE ProductCode = @OldProductCode "
                + "AND Description = @OldDescription "
                + "AND UnitPrice = @OldUnitPrice "
                + "AND OnHandQuantity = @OldOnHandQuantity ";
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            try
            {
                connection.Open();
                if (updateCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement
                = "DELETE FROM products "
                + "WHERE ProductCode = @ProductCode "
                + "AND Description = @Description "
                + "AND UnitPrice = @UnitPrice "
                + "AND OnHandQuantity = @OnHandQuantity ";
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            try
            {
                connection.Open();
                if (deleteCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
