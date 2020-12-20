using Microsoft.Extensions.Configuration;
using LoanApp.Logic;
using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoanApp.DTOs;
using LoanApp.Factory;

namespace LoanApp.Logic
{
    public class LoanLogic : ILoanLogic
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IAmortizationMethodFactory _amortizationMethodFactory;

        public LoanLogic(IConfiguration configuration, IMapper mapper, IAmortizationMethodFactory amortizationMethodFactory)
        {
            _configuration = configuration;
            _mapper = mapper;
            _amortizationMethodFactory = amortizationMethodFactory;
        }

        public IEnumerable<Loan> GetLoanTypes()
        {
            var loanTypes = _configuration.GetSection("Loan")?.GetChildren();
            return _mapper.Map<IEnumerable<Loan>>(loanTypes);
        }

        public Loan GetLoanType(string name)
        {
            var loanType = _configuration.GetSection("Loan")?.GetChildren()?.FirstOrDefault(x => x.Key == name);
            return _mapper.Map<Loan>(loanType);
        }

        public AmortizationDTO CalculateLoan(Loan loan)
        {
            return _amortizationMethodFactory.GetAmortizationMethod(loan.AmortizationMethod)?.CalculateLoan(loan);
        }
    }
}
