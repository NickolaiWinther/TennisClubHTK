using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClubHTK.Entities;

namespace TennisClubHTK.DAL
{
    public class MemberRepository : BaseRepository
    {
        public List<Member> GetAllMembers() 
            => HandleDate(ExecuteQuery("SELECT * FROM Members ORDER BY Active DESC"));




        private List<Member> HandleDate(DataTable dataTable)
        {
            List<Member> members = new List<Member>();

            if (dataTable is null)
            {
                return members;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                members.Add(new Member()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Address = (string)row["Address"],
                    Email = (string)row["Email"],
                    PhoneNumber = (string)row["PhoneNumber"],
                    Active = Convert.ToBoolean(row["Active"]),
                    BirthDate = (DateTime)row["BirthDate"],
                    AgeGroup = (AgeGroup)row["AgeGroup"],
                    Gender = (Gender)row["Gender"]
                });
            }

            return members;
        }

        
    }
}
