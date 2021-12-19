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
			if (subcomms[0] == "insert")
			{

			}
			if (check)
			{
				switch (subcomms[0])
				{
					case "show":
						ShowStudent(id);
						break;
					case "update":

						break;
					case "delete":
						DeleteStudent(id);
						break;
					default:
						Console.Error.WriteLine("Unknown command");
						break;
				}
			}
			else
			{
				Console.Error.WriteLine("Unknown command");
			}
		}

		public static void TeachersCommandsProceduring()
		{
			string command = Console.ReadLine();
			string[] subcomms = command.Split(' ');
			bool check = int.TryParse(subcomms[1], out int id);
			if (subcomms[0] == "insert")
			{

			}
			if (check)
			{
				switch (command)
				{
					case "show":
						ShowTeacher(id);
						break;
					case "update":

						break;
					case "delete":
						DeleteTeacher(id);
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
			switch (command)
			{
				case "show":

					break;
				case "delete":

					break;
				case "insert":

					break;
				default:
					Console.Error.WriteLine("Unknown command");
					break;
			}
		}

		public static void ShowStudent(int id)
		{
			studentsRepository.GetActualStudent(id);
		}
		public static void ShowTeacher(int id)
		{
			teachersRepository.GetActualTeacher(id);
		}
		public static void ShowSubjects()
		{
			subjectsRepository.GetSubjects();
		}

		public static bool InsertStudent(Student s)
		{
			if (s == null)
			{
				return studentsRepository.Insert(DataGenerator.GenerateStudent());
			}
			return studentsRepository.Insert(s);
		}

		public static bool InsertTeacher(Teacher t)
		{
			if (t == null)
			{
				return teachersRepository.Insert(DataGenerator.GenerateTeacher());
			}
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

		public static bool UpdateStudent(Student s)
		{
			return studentsRepository.Update(s);
		}

		public static bool UpdateTeacher(Teacher t)
		{
			return teachersRepository.Update(t);
		}

		public static bool UpdateSubject(Subject s)
		{
			return subjectsRepository.Update(s);
		}
	}
}
