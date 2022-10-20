using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Models.DTO
{
    public class MortgageResponse
    {
        public Guid Id { get; set; }

        public double? MaximumWorth { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime WatchTime { get; set; }
    }
}
