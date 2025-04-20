namespace ExaminationSystem.API.ViewModels.Choices
{
    public class ChoiceCreateViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
