using Group_IS_21zp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.Model
{
    public class Student : IUser, IExcelItem
    {
        public Student(long id, string firstName, string patronymicName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            PatronymicName = patronymicName;
            LastName = lastName;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string PatronymicName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {

            return String.Format("{0, 20} {1, 20} {2, 20} {3, 20}", Id, FirstName, PatronymicName, LastName);
        }
    }
}
