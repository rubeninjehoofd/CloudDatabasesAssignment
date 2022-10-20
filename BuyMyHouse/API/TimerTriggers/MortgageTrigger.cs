using BuyMyHouse.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = BuyMyHouse.Models.Timer;

namespace BuyMyHouse.API.TimerTriggers
{
    public class MortgageTrigger
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;


        public MortgageTrigger(ILoggerFactory loggerFactory, ICustomerService customerService)
        {
            _logger = loggerFactory.CreateLogger<MortgageTrigger>();
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [Function("ProcessFinancialInfo")]
        public void Run([TimerTrigger("0 59 23 * * *")] Timer myTimer)
        {
            _logger.LogInformation("Calculating mortgages for all users");
            _customerService.CalculateMortgages();
        }
    }
}
