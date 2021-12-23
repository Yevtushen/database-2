namespace courseProject
{
	class Teacher
	{
		public int id;
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
