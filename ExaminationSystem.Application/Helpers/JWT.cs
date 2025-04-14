using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Application.Helpers
{
    public class JWT
    {

        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }

        public double DurationInMinutes { get; set; }

        public string Key { get; set; }

    }
}
