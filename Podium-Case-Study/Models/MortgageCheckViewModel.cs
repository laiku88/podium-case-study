using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Models
{
    public class MortgageCheckViewModel
    {
        public ApplicantViewModel Applicant { get;set; }
        public double PropertyValue { get; set; }
        public double DepositAmount { get; set; }
    }
}
