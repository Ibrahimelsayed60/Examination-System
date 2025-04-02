using ExaminationSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Choice
{
    public class ChoiceCreateDto
    {
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

    }
}
