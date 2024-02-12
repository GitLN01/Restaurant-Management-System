using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ItemRepository
    {
        public List<Items> GetAllItems()
        {
            List<Items> results = new List<Items>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Items";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Items i = new Items();
                    i.item_id = sqlDataReader.GetInt32(0);
                    i.name = sqlDataReader.GetString(1);
                    i.price = sqlDataReader.GetDecimal(2);
                    i.category = sqlDataReader.GetString(3);

                    results.Add(i);
                }
            }
            return results;
        }
    }
}
