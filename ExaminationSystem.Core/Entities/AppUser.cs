using ExaminationSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Domain.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int AddressId { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

    }
}
