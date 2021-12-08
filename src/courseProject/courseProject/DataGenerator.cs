using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace courseProject
{
	class DataGenerator
	{
		public static Student GenerateStudent()
		{
			Random randomForAge = new Random();
			Random randomForScore = new Random();
			return new Student
			{
				id = 0,
				firstName = GetRandomString("D:\\victo\\kpi\\database-2\\data\\first_names.txt"),
				lastName = GetRandomString("D:\\victo\\kpi\\database-2\\data\\last_names.txt"),
				age = randomForAge.Next(6, 19),
				averageScore = randomForScore.Next(1, 13)

			};
		}

		public static Teacher GenerateTeacher()
		{
			Random randomForSubject = new Random();
			return new Teacher 
			{
				id = 0,
				firstName = GetRandomString("D:\\victo\\kpi\\database-2\\data\\first_names.txt"),
				lastName = GetRandomString("D:\\victo\\kpi\\database-2\\data\\last_names.txt"),
				subjectId = randomForSubject.Next(1, 12)
			};
		}

		private static string GetRandomString(string filePath)
		{
			Random random = new Random();
			List<string> newList = new List<string>();
			StreamReader sr = new StreamReader(filePath);
			while (true)
			{

				string s = sr.ReadLine();
				if (s == null)
				{
					break;
				}
				newList.Add(s);
			}
			sr.Close();
			int index = random.Next(newList.Count);
			return newList[index];
		}
	}
}
