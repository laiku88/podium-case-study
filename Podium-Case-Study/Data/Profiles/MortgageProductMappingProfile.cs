using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Podium_Case_Study.Data.Entities;
using Podium_Case_Study.Models;
namespace Podium_Case_Study.Data.Profiles
{
    public class MortgageProductMappingProfile : Profile
    {
        public MortgageProductMappingProfile()
        {
            CreateMap<MortgageProduct, MortgageProductViewModel>()
                .ForMember(x=>x.MortgageProductId, 
                    ex=>ex.MapFrom(x=>x.Id))
                .ForMember(x=>x.InterestRateType, ex=>ex.MapFrom(x=>x.InterestRateType.InterestRateTypeName))
                .ReverseMap();
            CreateMap<Applicant, ApplicantViewModel>()
                .ForMember(x => x.ApplicantId, ex => ex.MapFrom(x => x.Id))
                .ForMember(x=>x.DateOfBirth, ex=>ex.MapFrom(x=>x.Dob))
                .ReverseMap();
        }
    }
}
