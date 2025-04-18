using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Exam
{
    public class ExamAnswerDto
    {
        public int ExamQuestionId { get; set; }

        public int ChoiceId { get; set; }

    }
}
