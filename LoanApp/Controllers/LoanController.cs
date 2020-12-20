using LoanApp.Logic;
using LoanApp.Models;
using LoanApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LoanApp.DTOs;

namespace LoanApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanLogic _loanLogic;
        public LoanController(ILoanLogic loanLogic)
        {
            _loanLogic = loanLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Loan>> GetLoanTypes()
        {
            return Ok(_loanLogic.GetLoanTypes());
        }

        [HttpGet("amortization")]
        public ActionResult<IEnumerable<AmortizationMethodDTO>> GetAmortizationMethods()
        {
            return Ok(EnumHelper.EnumNameValues<AmortizationType>());
        }

        [HttpPost]
        public ActionResult<AmortizationDTO> CalculateLoan(Loan loan)
        {
            var realLoan = _loanLogic.GetLoanType(loan.Name);
            if (realLoan == null)
            {
                return BadRequest();
            }

            loan.InterestRate = realLoan.InterestRate;
            return Ok(_loanLogic.CalculateLoan(loan));
        }
    }
}
