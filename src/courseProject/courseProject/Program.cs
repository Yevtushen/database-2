using System;
using MySqlConnector;
//using MySql.Data.MySqlClient;

namespace courseProject
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "qwerty",
				Database = "schooldb"
		};

			var conn = new MySqlConnection(builder.ConnectionString);
			/*conn.Open();
			MySqlCommand command = conn.CreateCommand();
			command.CommandText = @"DELETE FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", 2);
			command.ExecuteNonQuery();
			*//*command.Parameters.AddWithValue("@first_name", "Vic");
			command.Parameters.AddWithValue("@last_name", "Dev");
			command.Parameters.AddWithValue("@age", 19);*//*
			//command.ExecuteScalar();
			conn.Close();*/

		}

	}
}
