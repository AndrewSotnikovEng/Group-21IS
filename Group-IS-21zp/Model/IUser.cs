using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.Model
{
    interface IUser
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
