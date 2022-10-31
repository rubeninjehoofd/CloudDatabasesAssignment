using BuyMyHouse.Models;

namespace BuyMyHouse.Services.Interfaces
{
    public interface IMortgageService : IBaseService<Mortgage>
    {
        public Task<Mortgage> GetMortgageByCustomer(Guid customerId);
    }
}
