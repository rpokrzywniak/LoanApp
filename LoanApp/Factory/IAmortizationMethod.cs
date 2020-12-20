using LoanApp.DTOs;
using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Factory
{
    public interface IAmortizationMethod
    {
        public AmortizationDTO CalculateLoan(Loan loan);
    }
}
