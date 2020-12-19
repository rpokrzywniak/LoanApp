using AutoMapper;
using LoanApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LoanApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoanController(ILogger<LoanController> logger, IConfiguration configuration, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Loan>> GetLoanTypes()
        {
            var loanTypes = _configuration.GetSection("Loan")?.GetChildren();
            if(loanTypes == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<IEnumerable<Loan>>(loanTypes));
        }
    }
}
