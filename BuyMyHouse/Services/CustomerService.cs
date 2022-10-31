using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models;
using BuyMyHouse.Services.Interfaces;

namespace BuyMyHouse.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IBaseRepository<Customer> repository) : base(repository) { }

        public async Task CalculateMortgages()
        {
             var customers = await _repository.GetAll();

            foreach (var customer in customers.ToList())
            {
                if (customer.Mortgage is null)
                {
                    var mortgage = new Mortgage()
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = customer.Id,
                        MaximumWorth = customer.MaxMortgageWorth 
                    };

                    customer.Mortgage = mortgage;
                }
                else
                {
                    customer.Mortgage.MaximumWorth = customer.MaxMortgageWorth;
                    customer.Mortgage.ExpiresAt = DateTime.Now.AddHours(12);
                }
            }

            await _repository.SaveChangesAsync();
        }

        public override Task<Customer> Create(Customer entity)
        {
            if (entity is null) 
            {
                return null;
            }
            return _repository.Create(entity);
        }
    }
}
