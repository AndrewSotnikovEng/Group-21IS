using System;

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

        public override string ToString()
        {
            return String.Format("{0, 20} {1, 20}", Id, Name);
        }
    }
}
