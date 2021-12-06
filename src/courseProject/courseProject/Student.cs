﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class Student
	{
		public long id;
		public string firstName;
		public string lastName;
		public int age;
		public double averageScore;
		
		public List<Subject> subjects;

		public Student()
		{
			id = 0;
			firstName = "";
			lastName = "";
			age = 0;
			averageScore = 0;
			subjects = new List<Subject>();
		}

		public override string ToString()
		{
			return $"#{id}: {firstName} {lastName}, {age} -- ";
		}
	}
}