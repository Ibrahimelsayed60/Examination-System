using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Course
{
    public class CourseCreateDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<int> InstructorsIDs { get; set; }

        public ICollection<int> StudentsIDs { get; set; }

    }
}
