using System;
using MySqlConnector;
using System.Linq;
using ScottPlot;
using System.Collections.Generic;
//using MySql.Data.MySqlClient;

namespace courseProject
{
	class Program
	{
		static void Main(string[] args)
		{
			/*conn.Open();
			MySqlCommand command = conn.CreateCommand();
			command.CommandText = @"DELETE FROM students WHERE id = @id";
			command.Parameters.AddWithValue("@id", 2);
			command.ExecuteNonQuery();
			*//*command.Parameters.AddWithValue("@first_name", "Vic");
			command.Parameters.AddWithValue("@last_name", "Dev");
			command.Parameters.AddWithValue("@age", 19);*//*
			//command.ExecuteScalar();
			conn.Close();*/
			StudentsRepository studentsRepository = new StudentsRepository(GetConnection());
			DrawPlotAgeGrade(studentsRepository);
		}

		public static void DrawPlotAgeGrade(StudentsRepository studentsRepository)
		{
			var plt = new ScottPlot.Plot(600, 800);
			List<Student> students = studentsRepository.GetAllStudents();
			var studentsAges = students.Select(s => s.age).Distinct().ToArray();
			Dictionary<string, double> teacherUnits = new Dictionary<string, double>();
			/*foreach (var g in studentsAges)
			{
				var units = students.Where(s => s.age == g).Sum(s => s.averageScore);
				teacherUnits.Add(g.ToString(), Convert.ToDouble(units));
			}*/
			for (int i = 1; i <= studentsAges.Count(); i++)
			{
				var g = studentsAges[i - 1];
				var units = students.Where(s => s.age == g).Sum(s => s.averageScore/i);
				teacherUnits.Add(g.ToString(), Convert.ToDouble(units));
			}
			double[] ys = teacherUnits.Values.ToArray();
			double[] xs = Enumerable.Range(1, teacherUnits.Count)
				.Select(i => i * 2.5).ToArray();
			plt.PlotBar(xs, ys, horizontal: true);
			plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);
			string[] labels = teacherUnits.Keys.ToArray();
			plt.YTicks(xs, labels);
			plt.SaveFig("./age-grade.png");
		}

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
