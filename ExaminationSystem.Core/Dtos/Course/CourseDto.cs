using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Course
{
    public class CourseDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
