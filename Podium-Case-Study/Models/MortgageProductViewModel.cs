using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Podium_Case_Study.Models
{
    public class MortgageProductViewModel
    {
        public int MortgageProductId { get; set; }
        public string Lender { get; set; }
        public double InterestRate { get; set; }
        public double LoanToValue { get; set; }
        public string InterestRateType { get; set; }
    }
}
