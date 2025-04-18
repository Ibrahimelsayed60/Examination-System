using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Exam
{
    public class ExamStudentDto
    {
        public int Id { get; set; }

        public int ExamId { get; set; }

        public int StudentId { get; set; }

        public double Score { get; set; }

        public List<ExamAnswerDto> Answers { get; set; }

    }
}
