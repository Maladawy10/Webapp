using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDatabase.Models
{
    public class StudentRequest
    {
        public string Name { get; set; }
        public int SSN { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
    }
}
