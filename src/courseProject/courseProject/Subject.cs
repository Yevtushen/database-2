using System.Collections.Generic;

namespace courseProject
{
	class Subject
	{
		public int id;
		public string name;

		public List<Teacher> teachers;
		public List<Student> students;

		public Subject()
		{
			name = "";
			teachers = new List<Teacher>();
			students = new List<Student>();
		}

		public override string ToString()
		{
			return $"{id}: {name}";
		}
	}
}
