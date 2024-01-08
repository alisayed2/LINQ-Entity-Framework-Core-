using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3.Entities
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string Phone { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
        public ICollection<TeacherTransfere> TeacherTransferes { get; set; } = new HashSet<TeacherTransfere>();

        [ForeignKey("School")]
        public int SchoolId {  get; set; }
        public School School { get; set;}

    }
}
