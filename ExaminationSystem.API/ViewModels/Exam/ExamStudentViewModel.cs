using ExaminationSystem.Domain.Dtos.Exam;

namespace ExaminationSystem.API.ViewModels.Exam
{
    public class ExamStudentViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public List<ExamAnswerDto> Answers { get; set; }
    }
}
