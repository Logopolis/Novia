namespace Api.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Api.Repos;
    using Microsoft.Extensions.Logging;
    using Api.Models;

    public class FundsController : Controller
    {
        private readonly IFundsRepo _fundsRepo;
        private readonly ILogger<FundsController> _logger;

        public FundsController(IFundsRepo fundsRepo, ILogger<FundsController> logger)
        {
            _fundsRepo = fundsRepo;
            _logger = logger;
        }

        [Route("Funds")]
        public IActionResult Get(
            [FromQuery]string name = null,
            [FromQuery]string code = null)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
            {
                return this.BadRequest("Cannot specify both manager and code.");
            }

            if (!string.IsNullOrEmpty(name))
            {
                return GetFundsByManager(name);
            }

            if (!string.IsNullOrEmpty(code))
            {
                return GetFundByCode(code);
            }

            return GetAllFunds();
        }

        private IActionResult GetFundsByManager(string name)
        {
            _logger.LogInformation($"GetFundsByManager called with {name}");
            var funds = _fundsRepo.GetAll();
            var filteredByManager = funds
                                        .Where(f => f.Name == name)
                                        .Select(f => FundViewModel.FromFundDetails(f));

            return this.Ok(filteredByManager);
        }

        private IActionResult GetFundByCode(string code)
        {
            _logger.LogInformation($"GetFundByCode called with {code}");
            var funds = _fundsRepo.GetAll();
            var fund = funds.SingleOrDefault(x => x.MarketCode == code);
            if (fund == null)
            {
                return this.NotFound();
            }

            return this.Ok(FundViewModel.FromFundDetails(fund));
        }

        private IActionResult GetAllFunds()
        {
            _logger.LogInformation($"GetAllFunds called");
            return this.Ok(_fundsRepo.GetAll().Select(f => FundViewModel.FromFundDetails(f)));
        }
    }
}