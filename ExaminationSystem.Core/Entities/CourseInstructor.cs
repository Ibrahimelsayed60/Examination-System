using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class CourseInstructor:BaseModel
    {

        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

    }
}
