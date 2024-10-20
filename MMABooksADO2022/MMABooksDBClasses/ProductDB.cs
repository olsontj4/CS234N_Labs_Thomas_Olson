using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
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
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    return product;
                }
                else
                {
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
        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT ProductCode FROM products WHERE LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                string productCode = selectCommand.ExecuteScalar().ToString();
                return productCode;
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
        /*public static string DeleteProduct(Product product)
        {

        }*/
        //TODO: Get list, Add, Delete, Update.
    }
}
