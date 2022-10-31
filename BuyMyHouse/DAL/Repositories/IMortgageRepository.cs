
using BuyMyHouse.Models;

namespace BuyMyHouse.DAL.Repositories
{
    public interface IMortgageRepository : IBaseRepository<Mortgage>
    {
        public Task<Mortgage> GetMortgageByCustomer(Guid customerId);
    }
}
