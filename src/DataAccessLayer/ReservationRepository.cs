using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReservationRepository
    {
        public List<Reservations> GetAllReservations()
        {
            List<Reservations> results = new List<Reservations>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Reservations";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Reservations r = new Reservations();
                    r.reservation_id = sqlDataReader.GetInt32(0);
                    r.customer_id = sqlDataReader.GetInt32(1);
                    r.name = sqlDataReader.GetString(2);
                    r.number_of_customers = sqlDataReader.GetInt32(3);
                    r.date = sqlDataReader.GetDateTime(4);

                    results.Add(r);
                }
            }
            return results;
        }

        public int InsertReservations(Reservations r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Reservations VALUES (@CustomerID, @Name, @NumberOfCustomers, @Date)";

                sqlCommand.Parameters.AddWithValue("@CustomerID", r.customer_id);
                sqlCommand.Parameters.AddWithValue("@Name", r.name);
                sqlCommand.Parameters.AddWithValue("@NumberOfCustomers", r.number_of_customers);
                sqlCommand.Parameters.AddWithValue("@Date", r.date);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateReservations(Reservations r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Reservations SET customer_id = @CustomerID, name = @Name, number_of_customers = @NumberOfCustomers, date = @Date WHERE reservation_id = @ReservationID";

                sqlCommand.Parameters.AddWithValue("@CustomerID", r.customer_id);
                sqlCommand.Parameters.AddWithValue("@Name", r.name);
                sqlCommand.Parameters.AddWithValue("@NumberOfCustomers", r.number_of_customers);
                sqlCommand.Parameters.AddWithValue("@Date", r.date);
                sqlCommand.Parameters.AddWithValue("@ReservationID", r.reservation_id);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteReservations(Reservations r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Reservations WHERE reservation_id = " + r.reservation_id;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
