using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.Model
{
    public class Subject : IExcelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Subject(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
