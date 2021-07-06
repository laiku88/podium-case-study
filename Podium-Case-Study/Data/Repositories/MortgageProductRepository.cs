using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Podium_Case_Study.Data.DbContext;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Data.Repositories
{
    public class MortgageProductRepository:IMortgageProductRepository
    {
        private readonly MortgageAppContext _ctx;

        public MortgageProductRepository(MortgageAppContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<MortgageProduct> GetMortgageProducts()
        {
            return _ctx.MortgageProducts.Include(x=>x.InterestRateType).ToList();
        }

        public MortgageProduct GetMortgageProductById(int id)
        {
            return _ctx.MortgageProducts.FirstOrDefault(x => x.Id == id);
        }
    }
}
