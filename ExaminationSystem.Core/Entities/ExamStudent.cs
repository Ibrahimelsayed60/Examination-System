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
        public int? ExamId { get; set; }

        public Student Student { get; set; }
        public int? StudentId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public bool IsSubmitted { get; set; }

        public double Score { get; set; }

        public List<ExamStudentAnswer> ExamStudentAnswers { get; set; }
    }
}
