using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3.Entities
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; } // Optional 
    }
}
