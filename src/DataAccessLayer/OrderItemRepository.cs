using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderItemRepository
    {
        public List<Order_Items> GetAllOrderItems()
        {
            List<Order_Items> results = new List<Order_Items>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Order_items";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Order_Items o = new Order_Items();
                    o.order_item_id = sqlDataReader.GetInt32(0);
                    o.customer_id = sqlDataReader.GetInt32(1);
                    o.order_id = sqlDataReader.GetInt32(2);
                    o.item_id = sqlDataReader.GetInt32(3);
                    o.quantity = sqlDataReader.GetInt32(4);
                    o.description = sqlDataReader.GetString(5);

                    results.Add(o);
                }
            }
            return results;
        }

        /* Method that adds elements in table Order_items */
        public int InsertOrderItems(Order_Items o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Order_items VALUES (@CustomerID, @OrderID, @ItemID, @Quantity, @Description)";

                sqlCommand.Parameters.AddWithValue("@CustomerID", o.customer_id);
                sqlCommand.Parameters.AddWithValue("@OrderID", o.order_id);
                sqlCommand.Parameters.AddWithValue("@ItemID", o.item_id);
                sqlCommand.Parameters.AddWithValue("@Quantity", o.quantity);
                sqlCommand.Parameters.AddWithValue("@Description", o.description);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        /* Method that updates elements in table Order_items */
        public int UpdateOrderItems(Order_Items o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Order_items SET customer_id = @CustomerID, order_id = @OrderID, item_id = @ItemID, quantity = @Quantity, description = @Description WHERE order_item_id = @OrderItemID";

                sqlCommand.Parameters.AddWithValue("@CustomerID", o.customer_id);
                sqlCommand.Parameters.AddWithValue("@OrderID", o.order_id);
                sqlCommand.Parameters.AddWithValue("@ItemID", o.item_id);
                sqlCommand.Parameters.AddWithValue("@Quantity", o.quantity);
                sqlCommand.Parameters.AddWithValue("@Description", o.description);
                sqlCommand.Parameters.AddWithValue("@OrderItemID", o.order_item_id);

                return sqlCommand.ExecuteNonQuery();
            }
        }


        /* Method that deletes elements from table Order_items */
        public int DeleteOrderItems(Order_Items o)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Order_items WHERE order_item_id = " + o.order_item_id;

                return sqlCommand.ExecuteNonQuery();
            }
        }

    }
}
