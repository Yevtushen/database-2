using System;
using MySqlConnector;
using System.Linq;
using ScottPlot;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;

namespace courseProject
{
	class Program
	{
		static void Main(string[] args)
		{
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
			//StudentsRepository studentsRepository = new StudentsRepository(GetConnection());
			//SubjectsRepository subjectsRepository = new SubjectsRepository(GetConnection());
			
		}

		public static MySqlConnection GetConnection()
		{
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "localhost",
				UserID = "root",
				Password = "qwerty",
				Database = "schooldb"
			};
			return new MySqlConnection(builder.ConnectionString);
		}
	}
}
