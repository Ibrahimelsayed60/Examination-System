using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Choice
{
    public class ChoiceDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

    }
}
