using System;
using System.Collections.Generic;
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

		private Teacher GetTeacher(MySqlDataReader reader)
		{
			return new Teacher
			{
				id = (int)reader["id"],
				firstName = (string)reader["first_name"],
				lastName = (string)reader["last_name"],
				subjectId = (int)reader["subject_id"]
			};
		}

		public Teacher GetActualTeacher(int id)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM teachers WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			MySqlDataReader reader = command.ExecuteReader();
			Teacher teacher = new Teacher();
			if (reader.Read())
			{
				teacher = GetTeacher(reader);
			}
			connection.Close();
			return teacher;
		}

		public bool Insert(Teacher t)
		{
			connection.Open();
			MySqlCommand command1 = connection.CreateCommand();
			command1.CommandText = @"INSERT INTO teachers (first_name, last_name, subject_id) VALUES (@first_name, @last_name, @subject_id);";
			command1.Parameters.AddWithValue("@first_name", t.firstName);
			command1.Parameters.AddWithValue("@last_name", t.lastName);
			command1.Parameters.AddWithValue("@subject_id", t.subjectId);
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
			command.CommandText = @"DELETE FROM teachers WHERE id = @id";
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public bool UpdateLastName(int id, string lastName)
		{
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"UPDATE teachers SET last_name = @last_name WHERE id = @id";
			command.Parameters.AddWithValue("@last_name", lastName);
			command.Parameters.AddWithValue("@id", id);
			int nChanged = command.ExecuteNonQuery();
			connection.Close();
			return (nChanged != 0);
		}

		public List<Teacher> GetTeachersBySubject(int subjectId)
		{
			List<Teacher> teachers = new List<Teacher>();
			connection.Open();
			MySqlCommand command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM teachers WHERE subject_id = @id";
			command.Parameters.AddWithValue("@id", subjectId);
			MySqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				teachers.Add(GetTeacher(reader));
			}
			connection.Close();
			return teachers;
		}
	}
}
