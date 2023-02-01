using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.Model
{
    public class Teacher : IUser, IExcelItem
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Specialities { get; set; }

        public Teacher(long id, string firstName, string patronymicName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
        }
    }
}
