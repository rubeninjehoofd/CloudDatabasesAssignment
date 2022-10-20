using BuyMyHouse.Services;
using BuyMyHouse.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = BuyMyHouse.Models.Timer;

namespace BuyMyHouse.API.TimerTriggers
{
    public class SendMailTrigger
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public SendMailTrigger(ILoggerFactory loggerFactory, IEmailService emailService)
        {
            _logger = loggerFactory.CreateLogger<SendMailTrigger>();
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [Function("SendMail")]
        public void Run([TimerTrigger("0 0 8 * * *")] Timer myTimer)
        {
            try
            {
                _logger.LogInformation("Sending mails to all customers");
                _emailService.SendMailToAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong while sending an email: {ex.Message}");
            }
        }
    }
}
