using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.DTOs
{
    public class AmortizationDTO
    {
        public IEnumerable<Amortization> AmortizationSchedule { get; set; }
        public double MonthlyPayment { get; set; }
        public double Total { get; set; }
        public double TotalInterest { get; set; }
    }
}
