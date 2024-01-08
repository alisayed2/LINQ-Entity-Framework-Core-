using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3.Entities
{
    internal class TeacherTransfere
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey("FromSchool")]
        public int fromSchoolId {  get; set; }
        public School FromSchool { get; set; }

        [ForeignKey("ToSchool")]
        public int ToSchoolId {  get; set; }
        public School ToSchool { get; set; }

    }
}
