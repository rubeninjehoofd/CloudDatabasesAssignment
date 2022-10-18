using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BuyMyHouse.API
{
    public class SendMail
    {
        private readonly ILogger _logger;

        public SendMail(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SendMail>();
        }

        [Function("SendMail")]
        public void Run([TimerTrigger("0 0 8 * * *")] MailResults myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MailResults
    {
        public MailScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MailScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
