using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisClubHTK.Entities
{
    public class Member
    {
		private int id;
		private string name;
		private string address;
		private string phoneNumber;
		private string email;
		private DateTime birthDate;
		private bool active;
		private Gender gender;
		private AgeGroup ageGroup;
		private int age;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public DateTime BirthDate
		{
			get { return birthDate; }
			set { birthDate = value; }
		}

		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		public Gender Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		public AgeGroup AgeGroup
		{
			get { return ageGroup; }
			set { ageGroup = value; }
		}

		public int Age
		{
			get {
				int year = DateTime.Today.Year - BirthDate.Year;

				if (DateTime.Today.Month < BirthDate.Month)
					year--;

				return year;
			}
		}
	}
}
