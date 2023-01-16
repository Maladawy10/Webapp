using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDatabase
{
    public class Subject
    {
        
        public string Description { get; set; }
        [Key]
        public string Name { get; set; }
    }
}
