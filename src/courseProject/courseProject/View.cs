using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class View
	{
		public static void EnrollToSchool()
		{
			Console.WriteLine("Enter data");
			Console.WriteLine("Enter first name:");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter last name:");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter student's age:");
			string years = Console.ReadLine();
			bool check = int.TryParse(years, out int age);
			while (!check)
			{
				Console.Error.WriteLine("You wrote age in the wrong format. Try again.");
				string anotherTry = Console.ReadLine();
				check = int.TryParse(anotherTry, out age);
			}
			Console.WriteLine("Enter student's score:");
			string grade = Console.ReadLine();
			check = double.TryParse(grade, out double score);
			while (!check)
			{
				Console.Error.WriteLine("You wrote score in the wrong format. Try again.");
				string anotherTry = Console.ReadLine();
				check = double.TryParse(anotherTry, out score);
			}

			Student student = new Student
			{
				id = 0,
				firstName = firstName,
				lastName = lastName,
				age = age,
				averageScore = score
			};
			if(Controller.InsertStudent(student))
			{
				Console.WriteLine("Insertion succeeded");
			}
			else
			{
				Console.WriteLine("Insertion failed.");
			}
		}

		public static void Expel(int id)
		{
			if (Controller.DeleteStudent(id))
			{
				Console.WriteLine("Deleted successfully");
			}
			else
			{
				Console.WriteLine("Failed to delete");
			}
		}

		public static void ShowStudent(int id)
		{
			Console.WriteLine(Controller.ShowStudent(id).ToString());
		}

		private static void TakeExams(int id)
		{
			Console.WriteLine("Enter new score:");
			string grade = Console.ReadLine();
			bool check = double.TryParse(grade, out double score);
			while (!check)
			{
				Console.Error.WriteLine("You wrote score in the wrong format. Try again.");
				string anotherTry = Console.ReadLine();
				check = double.TryParse(anotherTry, out score);
			}
			if (Controller.UpdateStudentsGrade(id, score))
			{
				Console.WriteLine("Updated successfully");
			}
			else
			{
				Console.WriteLine("Update failed");
			}
		}

		private static void AgeUp(int id)
		{
			Console.WriteLine("Enter new age:");
			string years = Console.ReadLine();
			bool check = int.TryParse(years, out int age);
			while (!check)
			{
				Console.Error.WriteLine("You wrote score in the wrong format. Try again.");
				string anotherTry = Console.ReadLine();
				check = int.TryParse(anotherTry, out age);
			}
			if (Controller.UpdateStudentsAge(id, age))
			{
				Console.WriteLine("Updated successfully");
			}
			else
			{
				Console.WriteLine("Update failed");
			}
		}

		public static void UpdateStudent(int id)
		{
			Console.WriteLine("Enter 1 if you want to update age or 2 if you want to update grade of the student");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					AgeUp(1);
					break;
				case "2":
					TakeExams(id);
					break;
				default:
					Console.Error.WriteLine("Unknown command");
					break;
			}
		}

		public static void GenerateStudents()
		{
			Console.WriteLine("Enter number of generated objects:");
			string n = Console.ReadLine();
			bool check = int.TryParse(n, out int number);
			while(!check)
			{
				Console.WriteLine("You entered number in the wrong format. Try again.");
				n = Console.ReadLine();
				check = int.TryParse(n, out number);
			}
			Controller.GenerateStudents(number);
			Console.WriteLine("Finished");
		}

		public static void HireTeacher()
		{
			Console.WriteLine("Enter data");
			Console.WriteLine("Enter first name:");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter last name:");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter subject's name:");
			string subjectName = Console.ReadLine();
			while (Controller.FindSubject(subjectName) == null)
			{
				Console.WriteLine("You were trying to find non-existing subject. Try again.");
				subjectName = Console.ReadLine();
			}
			Teacher teacher = new Teacher
			{
				id = 0,
				firstName = firstName,
				lastName = lastName,
				subjectId = Controller.FindSubject(subjectName).id
			};
			if (Controller.InsertTeacher(teacher))
			{
				Console.WriteLine("Insertion succeeded");
			}
			else
			{
				Console.WriteLine("Insertion failed.");
			}
		}

		public static void ShowTeacher(int id)
		{
			Console.WriteLine(Controller.ShowTeacher(id).ToString());
		}

		public static void FireTeacher(int id)
		{
			if (Controller.DeleteTeacher(id))
			{
				Console.WriteLine("Deleted successfully");
			}
			else
			{
				Console.WriteLine("Failed to delete");
			}
		}

		public static void MarryTeacher(int id)
		{
			Console.WriteLine("Enter new last name:");
			string lastName = Console.ReadLine();
			if (Controller.UpdateTeacher(id, lastName))
			{
				Console.WriteLine("Updated successfully.");
			}
			else
			{
				Console.WriteLine("Update failed.");
			}
		}

		public static void GenerateTeachers()
		{
			Console.WriteLine("Enter number of generated objects:");
			string n = Console.ReadLine();
			bool check = int.TryParse(n, out int number);
			while (!check)
			{
				Console.WriteLine("You entered number in the wrong format. Try again.");
				n = Console.ReadLine();
				check = int.TryParse(n, out number);
			}
			Controller.GenerateTeachers(number);
			Console.WriteLine("Finished");
		}

		public static void AddSubject()
		{
			Console.WriteLine("Enter name of the subject");
			string name = Console.ReadLine();
			Subject subject = new Subject
			{
				id = 0,
				name = name
			};
			if (Controller.InsertSubject(subject))
			{
				Console.WriteLine("Insertion succeeded");
			}
			else
			{
				Console.WriteLine("Insertion failed");
			}
		}

		public static void DeleteSubject(int id)
		{
			if (Controller.DeleteSubject(id))
			{
				Console.WriteLine("Deleted successfully.");
			}
			else
			{
				Console.WriteLine("Deleting failed");
			}
		}

		public static void ShowSubjects()
		{
			foreach (Subject s in Controller.ShowSubjects())
			{
				Console.WriteLine(s.ToString());
			}
		}

		public static void UpdateSubject(int id)
		{
			Console.WriteLine("Enter new name:");
			string name = Console.ReadLine();
			Controller.UpdateSubject(id, name);
		}
	}
}
