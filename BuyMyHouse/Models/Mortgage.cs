using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.Models
{
    public class Mortgage : Entity
    {
        public double? MaximumWorth { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime ExpiresAt { get; set; }

        public Mortgage()
        {
            ExpiresAt = DateTime.Now.AddHours(12);
        }
    }
}
