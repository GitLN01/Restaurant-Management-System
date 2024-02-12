using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderRepository
    {
        public List<Orders> GetAllOrders()
        {
            List<Orders> results = new List<Orders>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Orders";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Orders o = new Orders();
                    o.order_id = sqlDataReader.GetInt32(0);
                    o.customer_id = sqlDataReader.GetInt32(1);
                    o.time = sqlDataReader.GetDateTime(2);
                    o.table_number = sqlDataReader.GetInt32(3);

                    results.Add(o);
                }
            }
            return results;
        }

        /* Method that adds elements in table Orders */
        public int InsertOrders(Orders o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Orders VALUES (@CustomerId, @Time, @TableNumber)";

                sqlCommand.Parameters.AddWithValue("@CustomerId", o.customer_id);
                sqlCommand.Parameters.AddWithValue("@Time", o.time);
                sqlCommand.Parameters.AddWithValue("@TableNumber", o.table_number);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* Method that updates elements in table Orders */
        public int UpdateOrders(Orders o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Orders SET customer_id = @CustomerId, time = @Time, table_number = @TableNumber WHERE orderId = @OrderId";

                sqlCommand.Parameters.AddWithValue("@CustomerId", o.customer_id);
                sqlCommand.Parameters.AddWithValue("@Time", o.time);
                sqlCommand.Parameters.AddWithValue("@TableNumber", o.table_number);
                sqlCommand.Parameters.AddWithValue("@OrderId", o.order_id);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* Method that deletes elements from table Orders, based on its id */
        public int DeleteOrders(Orders o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Orders WHERE order_id = " + o.order_id;

                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
