using ExaminationSystem.Domain.Dtos.Choice;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int Grade { get; set; }

        public string DifficultyLevel { get; set; }

        public List<ChoiceDto> Choices { get; set; }


    }
}
