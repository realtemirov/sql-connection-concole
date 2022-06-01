using System;
using System.Data.SqlClient;

namespace sql_connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-1V4J5J0; Database=NORTHWND; Integrated Security=true";

            string query = "select ContactName, City, Country from Customers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query,connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(String.Format("{0,-30}", reader[i]));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
