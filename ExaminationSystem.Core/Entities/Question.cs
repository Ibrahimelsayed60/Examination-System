using ExaminationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Question:BaseModel
    {

        public string Text { get; set; }

        public int Grade { get; set; }

        public QuestionDifficulty  DifficultyLevel { get; set; }

        public HashSet<Choice> Choices { get; set; }

        public HashSet<ExamQuestion> ExamQuestions { get; set; }



    }
}
