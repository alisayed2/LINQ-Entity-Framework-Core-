using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3.Entities
{
    internal class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();

        [InverseProperty("FromSchool")]
        public ICollection<TeacherTransfere> CommingTeachers { get; set; } = new HashSet<TeacherTransfere>();

        [InverseProperty("ToSchool")]
        public ICollection<TeacherTransfere> GoseTeachers { get; set; } = new HashSet<TeacherTransfere>();

    }
}
