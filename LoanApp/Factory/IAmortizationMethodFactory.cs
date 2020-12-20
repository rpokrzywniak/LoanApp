using LoanApp.Models;
using System;

namespace LoanApp.Factory
{
    public interface IAmortizationMethodFactory
    {
        public IAmortizationMethod GetAmortizationMethod(AmortizationType type);
    }
}
