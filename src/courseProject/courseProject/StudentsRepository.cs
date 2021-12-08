using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace courseProject
{
	class StudentsRepository
	{
		private MySqlConnection connection;

		public StudentsRepository(MySqlConnection connection)
		{
			this.connection = connection;
		}

		public Student GetStudent(MySqlDataReader reader)
		{
			return new Student
			{
				id = (long)reader["id"],
				firstName = (string)reader["first_name"],
				lastName = (string)reader["last_name"],
				age = (int)reader["age"],
				averageScore = (double)reader["average_score"]
			};
		}

		public bool Insert(Student s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"INSERT INTO students (first_name, last_name, age) VALUES (@first_name, @last_name, @age)";
			command.Parameters.AddWithValue("@first_name", s.firstName);
			command.Parameters.AddWithValue("@last_name", s.lastName);
			command.Parameters.AddWithValue("@age", s.age);
			s.id = (long)command.ExecuteScalar();
			connection.Close();
			return (s.id != 0);
		}

		public bool Delete(Student s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"DELETE FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", s.id);
			long nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public bool Update(Student s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET first_name = @first_name, last_name = @last_name, age = @age WHERE id = @id";
			command.Parameters.AddWithValue("@first_name", s.firstName);
			command.Parameters.AddWithValue("@last_name", s.lastName);
			command.Parameters.AddWithValue("@age", s.age);
			command.Parameters.AddWithValue("@id", s.id);
			long nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public void FindByLesserScore(double score)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * IN students WHERE score < @score";
			command.Parameters.AddWithValue("@score", score);
		}

		public void FindByGreaterScore(double score)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * IN students WHERE score >= @score";
			command.Parameters.AddWithValue("@score", score);
		}
	}
}
