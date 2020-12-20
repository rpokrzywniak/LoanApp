using AutoMapper;
using LoanApp.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IConfigurationSection, Loan>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Key))
                .ForMember(dest =>
                    dest.InterestRate,
                    opt => opt.MapFrom(src => src.Value));

            CreateMap<IEnumerable<Amortization>, AmortizationDTO>()
                .ForMember(dest =>
                     dest.AmortizationSchedule,
                     opt => opt.MapFrom(src => src));
        }
    }
}
