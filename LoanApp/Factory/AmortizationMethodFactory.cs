using AutoMapper;
using LoanApp.Models;
using System;

namespace LoanApp.Factory
{
    public class AmortizationMethodFactory : IAmortizationMethodFactory
    {
        private readonly IMapper _mapper;
        public AmortizationMethodFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IAmortizationMethod GetAmortizationMethod(AmortizationType type)
        {
            return type switch
            {
                AmortizationType.SeriesLoanPrinciple => new SeriesLoanPrinciple(_mapper),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
