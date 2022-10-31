
namespace BuyMyHouse.Models.DTO
{
    public class MortgageResponse
    {
        public Guid Id { get; set; }

        public double? MaximumWorth { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
