using AutoMapper;
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
            // Add as many of these lines as you need to map your objects
            CreateMap<IConfigurationSection, Loan>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Key))
                .ForMember(dest =>
                    dest.InterestRate,
                    opt => opt.MapFrom(src => src.Value));
        }
    }
}
