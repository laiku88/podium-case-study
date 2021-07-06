using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Podium_Case_Study.Data.DbContext;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Data
{
    public class MortgageProductsSeeder
    {
        private readonly MortgageAppContext _ctx;
        private readonly IWebHostEnvironment _env;

        public MortgageProductsSeeder(MortgageAppContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }
        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (_ctx.InterestRateTypes.Any()) return;
            var jsonInterest = GetJson("data/interestRateTypeData.json");
            var interestRateType = JsonSerializer.Deserialize<IEnumerable<InterestRateType>>(jsonInterest);
            _ctx.Database.OpenConnection();
           
            _ctx.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.InterestRateTypes ON");
            _ctx.InterestRateTypes.AddRange(interestRateType);
            if (!_ctx.MortgageProducts.Any())
            {
                var jsonMortgageProds = GetJson("data/mortgageProductSeedData.json");
                var mortgageProds = JsonSerializer.Deserialize<IEnumerable<MortgageProduct>>(jsonMortgageProds);
                _ctx.MortgageProducts.AddRange(mortgageProds);
            }
            var result= _ctx.SaveChanges();
            _ctx.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.InterestRateTypes OFF");
            _ctx.Database.CloseConnection();
        }
        private string GetJson(string filePart)
        {
            var filePath = Path.Combine(_env.ContentRootPath, filePart);
            var json = File.ReadAllText(filePath);
            return json;
        }
    }
}
