using MySqlConnector;

namespace courseProject
{
	class Model
	{
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

		public static MySqlConnection GetSlaveConnection()
		{
			var builder = new MySqlConnectionStringBuilder
			{
				Server = "192.168.1.109",
				UserID = "vic",
				Password = "vic",
				Database = "schooldb"
			};
			return new MySqlConnection(builder.ConnectionString);
		}
	}
}
