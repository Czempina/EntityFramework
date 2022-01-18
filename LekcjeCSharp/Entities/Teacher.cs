using System;
using System.Collections.Generic;
using System.Text;

namespace LekcjeCSharp.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string MainSubject { get; set; }
    }
}
