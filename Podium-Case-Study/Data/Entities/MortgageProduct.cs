using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Podium_Case_Study.Data.Entities
{
    public class MortgageProduct
    {
        [Key]
        public int Id { get; set; }
        public string Lender { get; set; }
        public double InterestRate { get; set; }
        public double LoanToValue { get; set; }
        public int InterestRateTypeId { get; set; }
        [ForeignKey("InterestRateTypeId")]
        public virtual InterestRateType InterestRateType { get; set; }
    }

    public class InterestRateType
    {
        public int Id { get; set; }
        public string InterestRateTypeName { get; set; }
    }
}
