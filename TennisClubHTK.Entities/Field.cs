using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisClubHTK.Entities
{
    public class Field
    {
		private int id;
		private string fieldName;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string FieldName
		{
			get { return fieldName; }
			set { fieldName = value; }
		}
	}
}
