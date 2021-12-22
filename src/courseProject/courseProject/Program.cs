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
			/*MySqlConnection conn = Model.GetConnection();
			conn.Open();
			MySqlCommand command = conn.CreateCommand();
			command.CommandText = @"INSERT INTO students (first_name, last_name, age, average_score) VALUES ('Harry', 'Potter', 7, 10.4)";
			//command.Parameters.AddWithValue("@id", 2);
			//command.ExecuteNonQuery();
			*//*command.Parameters.AddWithValue("@first_name", "Vic");
			command.Parameters.AddWithValue("@last_name", "Dev");
			command.Parameters.AddWithValue("@age", 19);*//*
			command.ExecuteScalar();
			conn.Close();*/
			//StudentsRepository studentsRepository = new StudentsRepository(GetConnection());
			//SubjectsRepository subjectsRepository = new SubjectsRepository(GetConnection());

			Console.WriteLine("Enter 'exit' if you want to leave or 'choose' if you want to start working with tables");
			Controller.FirstCommandProcessing();
		}
	}
}
