using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Models;

namespace Podium_Case_Study.Domain
{
    public interface IMortgageProcessor
    {
        double GetLoanToValue(double deposit, double propertyValueAmount);
        bool DepositIsLessThanPropertyValue(double deposit, double propertyValueAmount);
        IEnumerable<MortgageProductViewModel> GetValidMortgageProductViewModels(double ltv);
    }
}
