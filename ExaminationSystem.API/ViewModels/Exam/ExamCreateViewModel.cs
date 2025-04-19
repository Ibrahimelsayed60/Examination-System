namespace ExaminationSystem.API.ViewModels.Exam
{
    public class ExamCreateViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }

        public int CourseId { get; set; }

        public int InstructorId { get; set; }

        public ICollection<int> QuestionsIDs { get; set; }
    }
}
