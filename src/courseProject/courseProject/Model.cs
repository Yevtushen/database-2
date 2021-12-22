using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
