using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Models.DTO
{
    public class HouseResponse
    {
        public Guid HouseId { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double Price { get; set; }
        public bool IsForSale { get; set; }
    }
}
