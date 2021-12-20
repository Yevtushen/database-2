using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;

namespace courseProject
{
	class Plot
	{
		/*public void DrawPlotTeacherGrade(StudentsRepository studentsRepository)
		{
			var plt = new ScottPlot.Plot(600, 800);
			var subjects = studentsRepository.GetTheBest().Select(t => t.lastName).Distinct();
			Dictionary<string, double> teacherUnits = new Dictionary<string, double>();
			foreach (var s in subjects)
			{
				var units = studentsRepository.GetTheBest().Where(t => t.lastName == s).Sum(t => t.Units);
				teacherUnits.Add(s, Convert.ToDouble(units));
			}
			double[] ys = teacherUnits.Values.ToArray();
			double[] xs = Enumerable.Range(1, teacherUnits.Count)
				.Select(i => i * 2.5).ToArray();
			plt.PlotBar(xs, ys, horizontal: true);
			plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);
			string[] labels = teacherUnits.Keys.ToArray();
			plt.YTicks(xs, labels);
			plt.SaveFig("./teacher-grade.png");
		}*/

		public static void DrawPlotAgeGrade(StudentsRepository studentsRepository)
		{
			var plt = new ScottPlot.Plot(600, 800);
			List<Student> students = studentsRepository.GetAllStudents();
			var studentsAges = students.Select(s => s.age).Distinct().ToArray();
			Dictionary<string, double> teacherUnits = new Dictionary<string, double>();

			for (int i = 1; i <= studentsAges.Count(); i++)
			{
				var g = studentsAges[i - 1];
				var units = students.Where(s => s.age == g).Sum(s => s.averageScore / i);
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
	}
}
