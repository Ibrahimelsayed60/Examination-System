using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class ExamStudent:BaseModel
    {

        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

    }
}
