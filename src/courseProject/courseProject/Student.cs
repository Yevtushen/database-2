using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class Student
	{
		public int id;
		public string firstName;
		public string lastName;
		public int age;
		public double averageScore;
		
		public List<Teacher> teachers;

		public Student()
		{
			id = 0;
			firstName = "";
			lastName = "";
			age = 0;
			averageScore = 0;
			teachers = new List<Teacher>();
		}

		public override string ToString()
		{
			return $"#{id}: {firstName} {lastName}, {age}";
		}
	}
}
