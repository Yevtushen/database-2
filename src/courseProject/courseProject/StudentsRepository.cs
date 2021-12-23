using System;
using System.Collections.Generic;
using System.Linq;
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

		private Student GetStudent(MySqlDataReader reader)
		{
			return new Student
			{
				id = (int)reader["id"],
				firstName = (string)reader["first_name"],
				lastName = (string)reader["last_name"],
				age = (int)reader["age"],
				averageScore = (double)reader["average_score"]
			};
		}

		public Student GetActualStudent(int id)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			MySqlDataReader reader = command.ExecuteReader();
			Student student = new Student();
			if (reader.Read())
			{
				student = GetStudent(reader);
			}
			connection.Close();
			return student;
		}

		public bool Insert(Student s)
		{
			connection.Open();
			MySqlCommand command1 = connection.CreateCommand();
			command1.CommandText = @"INSERT INTO students (first_name, last_name, age, average_score) VALUES (@first_name, @last_name, @age, @average_score)";
			command1.Parameters.AddWithValue("@first_name", s.firstName);
			command1.Parameters.AddWithValue("@last_name", s.lastName);
			command1.Parameters.AddWithValue("@age", s.age);
			command1.Parameters.AddWithValue("@average_score", s.averageScore);
			try
			{
				command1.ExecuteScalar();
			}
			catch (Exception ex)
			{
				connection.Close();
				return false;
			}
			connection.Close();
			return true;
		}

		public bool Delete(int id)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"DELETE FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public bool UpdateAge(int id, int age)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET age = @age WHERE id = @id";
			command.Parameters.AddWithValue("@age", age);
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}
		public bool UpdateGrade(int id, double averageScore)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET average_score = @average_score WHERE id = @id";
			command.Parameters.AddWithValue("@average_score", averageScore);
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public List<Student> GetAllStudents()
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM students";
			MySqlDataReader reader = command.ExecuteReader();
			List<Student> students = new List<Student>();
			while (reader.Read())
			{
				students.Add(GetStudent(reader));
			}
			connection.Close();
			return students;
		}
	}
}
