using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Instructor:User
    {

        public DateTime HiringDate { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public HashSet<Exam> Exams { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }

    }
}
