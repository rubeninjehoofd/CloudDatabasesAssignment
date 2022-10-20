using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.Models
{
    public class Mortgage : Entity
    {
        public double? Worth { get; set; }

        public Guid UserId { get; set; }

        public DateTime WatchTime { get; set; }

        public Mortgage(double? worth)
        {
            Worth = worth;
            WatchTime = DateTime.Now;
        }
    }
}
