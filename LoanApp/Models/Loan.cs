using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Loan
    {
        public string Name { get; set; }
        public double InterestRate { get; set; }
        public int Amount { get; set; }
        public int Period { get; set; }
        public AmortizationType AmortizationMethod { get; set; }
    }
}
