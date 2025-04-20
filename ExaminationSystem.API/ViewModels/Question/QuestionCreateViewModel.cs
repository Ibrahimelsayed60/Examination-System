using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Enums;

namespace ExaminationSystem.API.ViewModels.Question
{
    public class QuestionCreateViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int Grade { get; set; }

        public QuestionDifficulty DifficultyLevel { get; set; }

        public List<ChoiceDto>? Choices { get; set; }
    }
}
