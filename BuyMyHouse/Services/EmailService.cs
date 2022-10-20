using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models;
using BuyMyHouse.Services.Interfaces;

namespace BuyMyHouse.Services
{
    public class EmailService : IEmailService
    {
        private IBaseRepository<Customer> _customerRepository;
        private MortgageRepository _mortgageRepository;

        public EmailService(IBaseRepository<Customer> customerRepository, MortgageRepository mortgageRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mortgageRepository = mortgageRepository ?? throw new ArgumentNullException(nameof(mortgageRepository));

            // _mortgageRepository = mortgageRepository;
        }
        public async Task SendMail(Customer customer)
        {
            var mortgage = await _mortgageRepository.GetMortgageByCustomer(customer.Id);

            if (mortgage is null)
                throw new Exception("No mortgage found for this user");

            // send mail stuff
            PrepareMailMessage();
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

        private void PrepareMailMessage()
        {
            throw new NotImplementedException();
        }
    }
}
