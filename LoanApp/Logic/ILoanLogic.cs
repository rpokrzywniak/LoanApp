using LoanApp.DTOs;
using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Logic
{
    public interface ILoanLogic
    {
        public IEnumerable<Loan> GetLoanTypes();
        public Loan GetLoanType(string name);
        public AmortizationDTO CalculateLoan(Loan loan);
    }
}
