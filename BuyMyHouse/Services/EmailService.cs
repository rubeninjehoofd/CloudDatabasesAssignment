using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models;
using BuyMyHouse.Services.Interfaces;
using SendGrid.Helpers.Mail;
using SendGrid;
using BuyMyHouse.DAL;

namespace BuyMyHouse.Services
{
    public class EmailService : IEmailService
    {
        private IBaseRepository<Customer> _customerRepository;
        private IMortgageRepository _mortgageRepository;
        private readonly FunctionConfiguration _config;

        public EmailService(IBaseRepository<Customer> customerRepository, IMortgageRepository mortgageRepository, FunctionConfiguration config)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mortgageRepository = mortgageRepository ?? throw new ArgumentNullException(nameof(mortgageRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task SendMailToAll()
        {
            var customers = await _customerRepository.GetAll();

            if (customers is null)
                throw new Exception("Something went wrong while retrieving the customers in the system");
            if (customers.Count < 1)
                throw new Exception("There are no customers in the system to send a mail to");

            foreach (var customer in customers.ToList())
                await SendMail(customer);
        }

        private async Task SendMail(Customer customer)
        {
            var mortgage = await _mortgageRepository.GetMortgageByCustomer(customer.Id);

            if (mortgage is null)
                throw new Exception("No mortgage found for this user");

            await PrepareMailMessage(customer);
        }

        private async Task PrepareMailMessage(Customer customer)
        {
            // Prepare client
            string apiKey = _config.SendGridApiKey;
            SendGridClient client = new SendGridClient(apiKey);
            
            // Prepare from address
            EmailAddress from = new EmailAddress(_config.MailSender, "Marco willems");
            string subject = "Maximum calculated mortgage";

            // Prepare to address
            EmailAddress to = new EmailAddress(customer.Email, $"{customer.FirstName} {customer.LastName}");
            string plainTextContent = $"Dear {customer.FirstName}, The maximum worth of your mortgage can be seen by following this link. This link is available for 12 hours.";
            string htmlContent = $"Dear {customer.FirstName}, <br><br> The maximum worth of your mortgage can be seen by following this link. This link is available for 12 hours. </n> <a href='http://localhost:7132/api/mortgages/{customer.Id}'>Click Here</a>";

            // Create and send the email
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
