using BuyMyHouse.Models;

namespace BuyMyHouse.Services.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        public Task CalculateMortgages();
    }
}
