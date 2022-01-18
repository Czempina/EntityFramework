using System;
using System.Collections.Generic;
using System.Text;

namespace LekcjeCSharp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int? Age { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ClassesId { get; set; }
        public virtual Class Class { get; set; }
    }
}
