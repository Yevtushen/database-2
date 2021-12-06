using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseProject
{
	class Teacher
	{
		public long id;
		public string firstName;
		public string lastName;
		public long subjectId;

		public Teacher()
		{
			firstName = "";
			lastName = "";
			subjectId = 0;
		}

		public override string ToString()
		{
			return $"#{id}: {firstName} {lastName}";
		}
	}
}
