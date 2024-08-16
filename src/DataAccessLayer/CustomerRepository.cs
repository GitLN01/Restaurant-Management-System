using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerRepository
    {
        public List<Customers> GetAllCustomers()
        {
            List<Customers> results = new List<Customers>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Customers";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customers c = new Customers();
                    c.customer_id = sqlDataReader.GetInt32(0);
                    c.name = sqlDataReader.GetString(1);
                    c.email = sqlDataReader.GetString(2);
                    c.password = sqlDataReader.GetString(3);
                    c.contact = sqlDataReader.GetString(4);

                    results.Add(c);
                }
            }
                return results;
        }

        public int InsertCustomers(Customers c)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Customers VALUES (@Name, @Email, @Password, @Contact)";

                sqlCommand.Parameters.AddWithValue("@Name", c.name);
                sqlCommand.Parameters.AddWithValue("@Email", c.email);
                sqlCommand.Parameters.AddWithValue("@Password", c.password);
                sqlCommand.Parameters.AddWithValue("@Contact", c.contact);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
