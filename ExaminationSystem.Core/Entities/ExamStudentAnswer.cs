using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class ExamStudentAnswer:BaseModel
    {

        public ExamQuestion ExamQuestion { get; set; }
        public int ExamQuestionId { get; set; }

        public Choice Choice { get; set; }
        public int ChoiceId { get; set; }

        public ExamStudent ExamStudent { get; set; }

        public int ExamStudentId { get; set; }

    }
}
