using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisClubHTK.Entities
{
    public class FieldReservation
    {
		private int id;
		private Member member1;
		private Member member;
		private Field field;
		private DateTime reservationTime;

		public DateTime ReservationTime
		{
			get { return reservationTime; }
			set { reservationTime = value; }
		}

		public Field Field
		{
			get { return field; }
			set { field = value; }
		}

		public Member Member2
		{
			get { return member; }
			set { member = value; }
		}

		public Member Member1
		{
			get { return member1; }
			set { member1 = value; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
