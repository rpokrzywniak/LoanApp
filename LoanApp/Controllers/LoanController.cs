using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoanApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly IConfiguration _configuration;

        public LoanController(ILogger<LoanController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<double> GetLoanTypes()
        {
            _configuration.GetSection("Loan");
            return 2;
        }
    }
}
