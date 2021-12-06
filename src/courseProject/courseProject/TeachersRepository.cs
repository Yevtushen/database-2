using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace courseProject
{
	class TeachersRepository
	{
		MySqlConnection connection;

		public TeachersRepository(MySqlConnection connection)
		{
			this.connection = connection;
		}

		public Teacher GetTeacher(MySqlDataReader reader)
		{
			return new Teacher
			{
				id = (long)reader["id"],
				firstName = (string)reader["first_name"],
				lastName = (string)reader["last_name"],
				subjectId = (long)reader["subject_id"]
			};
		}

		public bool Insert(Teacher t)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"INSERT INTO teachers (first_name, last_name, subject_id) VALUES (@first_name, @last_name, @subject_id);";
			command.Parameters.AddWithValue("@first_name", t.firstName);
			command.Parameters.AddWithValue("@last_name", t.lastName);
			command.Parameters.AddWithValue("@subject_id", t.subjectId);
			t.id = (long)command.ExecuteScalar();
			connection.Close();
			return (t.id != 0);
		}

		public bool Delete(Teacher t)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"DELETE FROM teachers WHERE id = @id";
			command.Parameters.AddWithValue("@id", t.id);
			long nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public bool Update(Teacher t)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE teachers SET first_name = @first_name, last_name = @last_name, subject_id = @subject_id WHERE id = @id";
			command.Parameters.AddWithValue("@first_name", t.firstName);
			command.Parameters.AddWithValue("@last_name", t.lastName);
			command.Parameters.AddWithValue("@subject_id", t.subjectId);
			command.Parameters.AddWithValue("@id", t.id);
			long nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}


	}
}
