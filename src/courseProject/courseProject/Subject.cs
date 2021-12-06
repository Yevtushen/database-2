using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class Subject
	{
		public long id;
		public string name;

		public List<Teacher> teachers;
		public List<Student> students;

		public Subject()
		{
			name = "";
			teachers = new List<Teacher>();
			students = new List<Student>();
		}
	}
}
