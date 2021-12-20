using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class Controller
	{
		public static StudentsRepository studentsRepository = new StudentsRepository(Program.GetConnection());
		public static TeachersRepository teachersRepository = new TeachersRepository(Program.GetConnection());
		public static SubjectsRepository subjectsRepository = new SubjectsRepository(Program.GetConnection());

		public static void FirstCommandProcessing()
		{
			while (true)
			{
				string command = Console.ReadLine();
				if (command == "exit")
				{
					break;
				}
				else if (command == "choose")
				{
					
				}
				else
				{
					Console.Error.WriteLine("Unknown command");
				}
			}
		}

		public static void ConcreteTable()
		{
			string command = Console.ReadLine();
			switch (command)
			{
				case "students":

					break;
				case "teachers":

					break;
				case "subjects":

					break;
				default:
					Console.Error.WriteLine("Table does not exist");
					break;
			}
		}

		public static void StudentsCommandsProceduring()
		{
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			bool check = int.TryParse(subcomms[1], out int id);
			
			if (check)
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

		public static void TeachersCommandsProceduring()
		{
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			bool check = int.TryParse(subcomms[1], out int id);
			if (check)
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
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
		}

		public static void SubjectsCommandsProceduring()
		{
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			bool check = int.TryParse(subcomms[1], out int id);
			if (check)
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
	}
}
