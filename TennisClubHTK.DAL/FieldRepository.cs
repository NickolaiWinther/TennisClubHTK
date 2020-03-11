using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClubHTK.Entities;

namespace TennisClubHTK.DAL
{
    public class FieldRepository : BaseRepository
    {
        public List<Field> GetAllFields()
            => HandleData(ExecuteQuery("SELECT * FROM Fields ORDER BY FieldName DESC"));

        public Field GetFieldById(int id)
            => HandleData(ExecuteQuery($"SELECT * FROM Fields WHERE Id = {id}")).FirstOrDefault();



        private List<Field> HandleData(DataTable dataTable)
        {
            List<Field> fields = new List<Field>();

            if (dataTable is null)
            {
                return fields;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                fields.Add(new Field()
                {
                    Id = (int)row["Id"],
                    FieldName = (string)row["FieldName"]
                });
            }

            return fields;
        }
    }
}
