using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Course:BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

        public HashSet<Exam> Exams { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }

    }
}
