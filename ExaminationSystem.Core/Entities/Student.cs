using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Student:AppUser
    {
        public DateTime EnrollmentDate { get; set; }

        public double GPA { get; set; }

        public Department Major { get; set; }
        public int MajorId { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }

        public List<ExamStudent> ExamStudents { get; set; }
    }
}
