using AutoMapper;
using LoanApp.DTOs;
using LoanApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Factory
{
    public class SeriesLoanPrinciple : IAmortizationMethod
    {
        private readonly IMapper _mapper;
        public SeriesLoanPrinciple(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AmortizationDTO CalculateLoan(Loan loan)
        {
            var monthlyRate = loan.InterestRate / (100 * 12); //divide by 100 because it's in percent's, then by 12 because these are monthly payments per year.
            var monthlyPayment = GetMonthlyPayment(loan, monthlyRate);
            var loanBalance = (double)loan.Amount;
            var amortization = new List<Amortization>();
            ushort period = 1;
            double totalInterest = 0;
            while (Math.Round(loanBalance, 2) > 0)
            {
                var monthlyInterest = monthlyRate * loanBalance;
                var principal = monthlyPayment - monthlyInterest;
                amortization.Add(new Amortization
                {
                    Period = period++,
                    StartingBalance = loanBalance,
                    Interest = monthlyInterest,
                    Principal = principal,
                    RemainingBalance = loanBalance -= principal
                });
                loanBalance = amortization.Last().RemainingBalance;
                totalInterest += monthlyInterest;
            }

            return GetAmortizationSchedule(amortization, monthlyPayment, loan.Period, totalInterest);
        }

        private double GetMonthlyPayment(Loan loan, double monthlyRate)
        {
            var divident = (Math.Pow(1 + monthlyRate, loan.Period) - 1) / (monthlyRate * Math.Pow(1 + monthlyRate, loan.Period));
            return loan.Amount / divident;
        }

        private void RoundAmortization(AmortizationDTO amortizationSchedule)
        {
            foreach (var amortization in amortizationSchedule.AmortizationSchedule)
            {
                amortization.StartingBalance = Math.Round(amortization.StartingBalance, 2);
                amortization.Principal = Math.Round(amortization.Principal, 2);
                amortization.RemainingBalance = Math.Round(amortization.RemainingBalance, 2);
                amortization.Interest = Math.Round(amortization.Interest, 2);
            }

            amortizationSchedule.MonthlyPayment = Math.Round(amortizationSchedule.MonthlyPayment, 2);
            amortizationSchedule.Total = Math.Round(amortizationSchedule.Total, 2);
            amortizationSchedule.TotalInterest = Math.Round(amortizationSchedule.TotalInterest, 2);
        }

        private AmortizationDTO GetAmortizationSchedule(List<Amortization> amortization, double monthlyPayment, int period, double totalInterest)
        {
            var amortizationSchedule = _mapper.Map<AmortizationDTO>(amortization);
            amortizationSchedule.MonthlyPayment = monthlyPayment;
            amortizationSchedule.Total = monthlyPayment * period;
            amortizationSchedule.TotalInterest = totalInterest;
            RoundAmortization(amortizationSchedule);
            return amortizationSchedule;
        }
    }
}
