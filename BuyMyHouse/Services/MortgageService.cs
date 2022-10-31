using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models;
using BuyMyHouse.Services.Interfaces;

namespace BuyMyHouse.Services
{
    public class MortgageService : BaseService<Mortgage>, IMortgageService
    {
        private readonly IBaseRepository<Mortgage> _baseRepository;
        private readonly IMortgageRepository _mortgageRepository;

        public MortgageService(IBaseRepository<Mortgage> repository, IMortgageRepository mortgageRepository) : base(repository)
        {
            _baseRepository = repository;
            _mortgageRepository = mortgageRepository;
        }

        public async Task<Mortgage> GetMortgageByCustomer(Guid customerId)
        {
            Mortgage mortgage = await _mortgageRepository.GetMortgageByCustomer(customerId);

            if (mortgage.ExpiresAt < DateTime.UtcNow)
            {
                throw new Exception("The expiry date to watch this mortgage has passed.");
            }
            return mortgage;
        }
    }
}
