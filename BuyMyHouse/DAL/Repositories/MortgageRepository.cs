using BuyMyHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyMyHouse.DAL.Repositories
{
    public class MortgageRepository : BaseRepository<Mortgage>
    {
        public MortgageRepository(BuyHouseContext dbContext) : base(dbContext) { }

        public async Task<Mortgage> GetMortgageByCustomer(Guid customerId)
        {
            var customer = await _buyMyHouseContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
            return customer.Mortgage;
        }
    }
}
