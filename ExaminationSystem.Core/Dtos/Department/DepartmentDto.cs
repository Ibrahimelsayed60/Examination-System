using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public ICollection<int> CoursesIDs { get; set; }
        public ICollection<int> InstructorsIDs { get; set; }
        public ICollection<int> StudentsIDs { get; set; }

    }
}
