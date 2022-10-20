using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.Models
{
    public class Mortgage : Entity
    {
        public double? MaximumWorth { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime WatchTime { get; set; }

        public Mortgage()
        {
            WatchTime = DateTime.Now;
        }
    }
}
