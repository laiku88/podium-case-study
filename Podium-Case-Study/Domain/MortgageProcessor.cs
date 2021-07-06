using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Data.Repositories;
using Podium_Case_Study.Models;

namespace Podium_Case_Study.Domain
{
    public class MortgageProcessor:IMortgageProcessor
    {
        private readonly IMortgageProductRepository _repository;
        private readonly IMapper _mapper;

        public MortgageProcessor(IMortgageProductRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            _mapper = mapper;
        }

        public double GetLoanToValue(double deposit, double propertyValueAmount)
        {
            //LTV is (property value - deposit) / property value * 100
            var ltv = (propertyValueAmount - deposit) / propertyValueAmount * 100;
            return ltv;
        }

        public bool DepositIsLessThanPropertyValue(double deposit, double propertyValueAmount)
        {
            return deposit < propertyValueAmount;
        }

        public IEnumerable<MortgageProductViewModel> GetValidMortgageProductViewModels(double ltv)
        {
            var mortgageProds = _repository.GetMortgageProducts();
            var validMortgageProds = mortgageProds.Where(x => x.LoanToValue <= ltv);
            var validMortgageProdVms = _mapper.Map<IEnumerable<MortgageProductViewModel>>(validMortgageProds);
            return validMortgageProdVms;
        }
    }
}
