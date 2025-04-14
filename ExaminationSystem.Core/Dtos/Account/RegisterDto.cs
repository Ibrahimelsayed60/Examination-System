using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Dtos.Account
{
    public class RegisterDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Type { get; set; }
    }
}
