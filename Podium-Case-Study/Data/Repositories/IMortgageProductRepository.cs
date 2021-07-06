using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Data.Repositories
{
    public interface IMortgageProductRepository
    {
        IEnumerable<MortgageProduct> GetMortgageProducts();
        MortgageProduct GetMortgageProductById(int id);
    }
}
