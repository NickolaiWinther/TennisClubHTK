using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClubHTK.Entities;

namespace TennisClubHTK.DAL
{
    public class FieldReservationRepository : BaseRepository
    {
        FieldRepository FieldRepository = new FieldRepository();
        MemberRepository MemberRepository = new MemberRepository();

        public List<FieldReservation> GetAllFieldReservations()
            => HandleData(ExecuteQuery("SELECT * FROM FieldReservations"));

        public List<FieldReservation> GetAllFieldReservationsByFieldId(int id)
            => HandleData(ExecuteQuery($"SELECT * FROM FieldReservations WHERE FieldId = {id}"));

        public void CreateFieldReservation(FieldReservation fr)
            => ExecuteNonQuery($"INSERT INTO FieldReservations VALUES ({fr.Member1.Id}, {fr.Member2.Id}, {fr.Field.Id}, '{fr.ReservationTime.ToString("yyyy-MM-dd HH")}:00:00')");

        private List<FieldReservation> HandleData(DataTable dataTable)
        {
            List<FieldReservation> fieldReservations = new List<FieldReservation>();

            if (dataTable is null)
            {
                return fieldReservations;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                fieldReservations.Add(new FieldReservation()
                {
                    Id = (int)row["Id"],
                    Field = FieldRepository.GetFieldById((int)row["FieldId"]),
                    Member1 = MemberRepository.GetMemberById((int)row["Member1Id"]),
                    Member2 = MemberRepository.GetMemberById((int)row["Member2Id"]),
                    ReservationTime = (DateTime)row["ReservationTime"]
                });
            }

            return fieldReservations;
        }

    }
}
