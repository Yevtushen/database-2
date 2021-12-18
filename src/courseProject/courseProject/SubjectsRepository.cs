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

		public Subject GetActualSubject(int id)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM subjects WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			MySqlDataReader reader = command.ExecuteReader();
			reader.Read();
			return GetSubject(reader);
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

		public bool Update(Subject s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE students SET name = @name WHERE id = @id";
			command.Parameters.AddWithValue("@name", s.name);
			command.Parameters.AddWithValue("@id", s.id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}
	}
}
