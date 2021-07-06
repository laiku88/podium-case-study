using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Podium_Case_Study.Data.Entities;

namespace Podium_Case_Study.Data.DbContext
{
    public class MortgageAppContext:Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration _config;

        public MortgageAppContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<MortgageProduct> MortgageProducts { get; set; }
        public DbSet<InterestRateType> InterestRateTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer(_config["ConnectionStrings:MortgageAppContextDb"]);
        }
    }
}
