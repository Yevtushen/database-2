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
				id = (long)reader["id"],
				name = (string)reader["name"],
			};
		}

		public bool Insert(Subject s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"INSERT INTO subjects (name) VALUES (@name)";
			command.Parameters.AddWithValue("@name", s.name);
			s.id = (long)command.ExecuteScalar();
			connection.Close();
			return (s.id != 0);
		}

		public bool Delete(Subject s)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"DELETE FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", s.id);
			long nChanged = command.ExecuteNonQuery();
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
			long nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}
	}
}
