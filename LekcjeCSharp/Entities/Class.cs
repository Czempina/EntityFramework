using System;
using System.Collections.Generic;
using System.Text;

namespace LekcjeCSharp.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public int TeachersId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public Class()
        {
            Students = new HashSet<Student>();
        }
    }
}
