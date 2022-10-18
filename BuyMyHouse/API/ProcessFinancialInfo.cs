using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BuyMyHouse.API
{
    public class ProcessFinancialInfo
    {
        private readonly ILogger _logger;

        public ProcessFinancialInfo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProcessFinancialInfo>();
        }

        [Function("ProcessFinancialInfo")]
        public void Run([TimerTrigger("0 59 23 * * *")] FinancialInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class FinancialInfo
    {
        public FinancialScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class FinancialScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
