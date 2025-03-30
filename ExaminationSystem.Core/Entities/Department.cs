using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Department:BaseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public List<Course> Courses { get; set; }

        public List<Student> Students { get; set; }

        public List<Instructor> Instructors { get; set; }
    }
}
