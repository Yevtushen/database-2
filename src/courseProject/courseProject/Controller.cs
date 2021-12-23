using System;
using System.Collections.Generic;

namespace courseProject
{
	class Controller
	{
		public static StudentsRepository studentsRepository = new StudentsRepository(Model.GetConnection());
		public static TeachersRepository teachersRepository = new TeachersRepository(Model.GetConnection());
		public static SubjectsRepository subjectsRepository = new SubjectsRepository(Model.GetConnection());

		public static StudentsRepository stRep = new StudentsRepository(Model.GetSlaveConnection());
		public static TeachersRepository tchRep = new TeachersRepository(Model.GetSlaveConnection());
		public static SubjectsRepository sbRep = new SubjectsRepository(Model.GetSlaveConnection());

		public static void FirstCommandProcessing()
		{
			while (true)
			{
				Console.WriteLine("Enter 'exit' if you want to leave, 'choose' if you want to start working with tables or 'draw' to create diagram");
				string command = Console.ReadLine();
				if (command == "exit")
				{
					break;
				}
				else if (command == "choose")
				{
					ConcreteTable();
				}
				else if (command == "draw")
				{
					DrawBars();
					Console.WriteLine("Done");
				}
				else
				{
					Console.Error.WriteLine("Unknown command");
				}
			}
		}

		private static void DrawBars()
		{
			Plot.DrawPlotAgeGrade(studentsRepository);
		}

		private static void ConcreteTable()
		{
			Console.WriteLine("Enter the name of the table you want to work with: students, teachers or subjects");
			string command = Console.ReadLine();
			switch (command)
			{
				case "students":
					StudentsCommandsProceduring();
					break;
				case "teachers":
					TeachersCommandsProceduring();
					break;
				case "subjects":
					SubjectsCommandsProceduring();
					break;
				default:
					Console.Error.WriteLine("Table does not exist");
					break;
			}
		}

		private static void StudentsCommandsProceduring()
		{
			Console.WriteLine("Enter your command");
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			
			if (subcomms.Length == 2 && int.TryParse(subcomms[1], out int id))
			{
				switch (subcomms[0])
				{
					case "show":
						View.ShowStudent(id);
						break;
					case "update":
						View.UpdateStudent(id);
						break;
					case "delete":
						View.Expel(id);
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
			else
			{
				switch (subcomms[0])
				{
					case "insert":
						View.EnrollToSchool();
						break;
					case "generate":
						View.GenerateStudents();
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
		}

		private static void TeachersCommandsProceduring()
		{
			Console.WriteLine("Enter your command");
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			if (subcomms.Length == 2 && int.TryParse(subcomms[1], out int id))
			{
				switch (subcomms[0])
				{
					case "show":
						View.ShowTeacher(id);
						break;
					case "update":
						View.MarryTeacher(id);
						break;
					case "delete":
						View.FireTeacher(id);
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
			else
			{
				switch (subcomms[0])
				{
					case "insert":
						View.HireTeacher();
						break;
					case "generate":
						View.GenerateTeachers();
						break;
					case "find":
						View.FindBySubject();
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
		}

		private static void SubjectsCommandsProceduring()
		{
			Console.WriteLine("Enter your command");
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			if (subcomms.Length == 2 && int.TryParse(subcomms[1], out int id))
			{
				switch (subcomms[0])
				{
					case "delete":
						View.DeleteSubject(id);
						break;
					case "update":
						View.UpdateSubject(id);
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
			else
			{
				switch (subcomms[0])
				{
					case "insert":
						View.AddSubject();
						break;
					case "show":
						View.ShowSubjects();
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
		}

		public static Student ShowStudent(int id)
		{
			return studentsRepository.GetActualStudent(id);
		}
		public static Teacher ShowTeacher(int id)
		{
			return teachersRepository.GetActualTeacher(id);
		}
		public static List<Subject> ShowSubjects()
		{
			return subjectsRepository.GetSubjects();
		}

		public static bool InsertStudent(Student s)
		{
			return studentsRepository.Insert(s);
		}

		public static bool InsertTeacher(Teacher t)
		{
			return teachersRepository.Insert(t);
		}

		public static bool InsertSubject(Subject s)
		{
			return subjectsRepository.Insert(s);
		}

		public static bool DeleteStudent(int id)
		{
			return studentsRepository.Delete(id);
		}

		public static bool DeleteTeacher(int id)
		{
			return teachersRepository.Delete(id);
		}

		public static bool DeleteSubject(int id)
		{
			return subjectsRepository.Delete(id);
		}

		public static bool UpdateStudentsGrade(int id, double score)
		{
			return studentsRepository.UpdateGrade(id, score);
		}

		public static bool UpdateStudentsAge(int id, int age)
		{
			return studentsRepository.UpdateAge(id, age);
		}

		public static bool UpdateTeacher(int id, string lastName)
		{
			return teachersRepository.UpdateLastName(id, lastName);
		}

		public static bool UpdateSubject(int id, string name)
		{
			return subjectsRepository.Update(id, name);
		}

		public static Subject FindSubject(string name)
		{
			return subjectsRepository.FindSubject(name);
		}

		public static void GenerateStudents(int numberOfStudents)
		{
			List<Student> students = new List<Student>();
			for (int i = 0; i < numberOfStudents; i++)
			{
				students.Add(DataGenerator.GenerateStudent());
			}
			foreach (Student s in students)
			{
				studentsRepository.Insert(s);
			}
		}

		public static void GenerateTeachers(int numberOfTeachers)
		{
			List<Teacher> teachers = new List<Teacher>();
			for (int i = 0; i < numberOfTeachers; i++)
			{
				teachers.Add(DataGenerator.GenerateTeacher());
			}
			foreach (Teacher t in teachers)
			{
				teachersRepository.Insert(t);
			}
		}

		public static List<Teacher> FindTeachers(int subjectId)
		{
			return teachersRepository.GetTeachersBySubject(subjectId);
		}
	}
}
