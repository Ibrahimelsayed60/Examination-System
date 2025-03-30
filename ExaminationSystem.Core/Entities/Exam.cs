using ExaminationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Exam:BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalPoints { get; set; }

        public ExamType Type { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }

    }
}
