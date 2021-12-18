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
			reader.Read();
			return GetStudent(reader);
		}

		public bool Insert(Student s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM students WHERE first_name = @first_name, last_name = @last_name; age = @age, average_score = @average_score";
			command.Parameters.AddWithValue("@first_name", s.firstName);
			command.Parameters.AddWithValue("@last_name", s.lastName);
			command.Parameters.AddWithValue("@age", s.age);
			command.Parameters.AddWithValue("@average_score", s.averageScore);
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				return false;
			}
			MySqlCommand command1 = connection.CreateCommand();
			command1.CommandText = @"INSERT INTO students (first_name, last_name, age, average_score) VALUES (@first_name, @last_name, @age, @average_score)";
			command1.Parameters.AddWithValue("@first_name", s.firstName);
			command1.Parameters.AddWithValue("@last_name", s.lastName);
			command1.Parameters.AddWithValue("@age", s.age);
			command1.Parameters.AddWithValue("@average_score", s.averageScore);
			s.id = (int)command1.ExecuteScalar();
			connection.Close();
			return (s.id != 0);
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

		public bool Update(Student s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET first_name = @first_name, last_name = @last_name, age = @age WHERE id = @id";
			command.Parameters.AddWithValue("@first_name", s.firstName);
			command.Parameters.AddWithValue("@last_name", s.lastName);
			command.Parameters.AddWithValue("@age", s.age);
			command.Parameters.AddWithValue("@id", s.id);
			/*command.CommandText = @"UPDATE students SET @column = @parameter WHERE id = @id";
			command.Parameters.AddWithValue("@column", column);
			command.Parameters.AddWithValue("@parameter", parameter);
			command.Parameters.AddWithValue("@id", id);*/
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		/*public void FindByLesserScore(double score)
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
		}*/

		public string GetTheBest()
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * IN students WHERE score > 9";
			MySqlDataReader reader = command.ExecuteReader();
			List<Student> students = new List<Student>();
			
			while (reader.Read())
			{
				students.Add(GetStudent(reader));
			}
			List<List<Teacher>> lists = new List<List<Teacher>>();
			foreach (Student s in students)
			{
				lists.Add(s.teachers);
			}
			var common = lists.First().AsEnumerable();
			foreach (var list in lists.Skip(1))
			{
				common = common.Intersect(list);
			}
			string result = "";
			foreach (Teacher t in common)
			{
				result += t.ToString() + "\r\n";
			}

			return result;
		}
	}
}
