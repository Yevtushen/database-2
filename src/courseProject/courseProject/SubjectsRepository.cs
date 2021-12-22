using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace courseProject
{
	class SubjectsRepository
	{
		MySqlConnection connection;

		public SubjectsRepository(MySqlConnection connection)
		{
			this.connection = connection;
		}

		public Subject GetSubject(MySqlDataReader reader)
		{
			return new Subject
			{
				id = (int)reader["id"],
				name = (string)reader["name"],
			};
		}

		public List<Subject> GetSubjects()
		{
			connection.Open();
			List<Subject> subjects = new List<Subject>();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM subjects";
			MySqlDataReader reader = command.ExecuteReader();
			while(reader.Read())
			{
				subjects.Add(GetSubject(reader));
			}
			connection.Close();
			return subjects;
		}

		public Subject FindSubject(string name)
		{
			connection.Open();
			Subject subject = new Subject();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM subjects WHERE name = @name";
			command.Parameters.AddWithValue("@name", name);
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				subject = GetSubject(reader);
			}
			connection.Close();
			return subject;
		}

		public bool Insert(Subject s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM subjects WHERE name = @name";
			command.Parameters.AddWithValue("@name", s.name);
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				return false;
			}
			MySqlCommand command1 = connection.CreateCommand();
			command1.CommandText = @"INSERT INTO subjects (name) VALUES (@name)";
			command1.Parameters.AddWithValue("@name", s.name);
			try
			{
				command1.ExecuteScalar();
			}
			catch
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

		public bool Update(int id, string name)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET name = @name WHERE id = @id";
			command.Parameters.AddWithValue("@name", name);
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}
	}
}
