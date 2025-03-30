using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class ExamQuestion:BaseModel
    {
        public Exam Exam { get; set; }
        public int ExamId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }

    }
}
