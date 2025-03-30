using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class Choice:BaseModel
    {

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public Question Question { get; set; }

        public int QuestionId { get; set; }

    }
}
