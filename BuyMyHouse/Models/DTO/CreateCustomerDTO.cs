using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace BuyMyHouse.Models.DTO
{
    public class CreateCustomerDTO
    {
        [JsonRequired]
        [OpenApiProperty(Default = "Marco", Description = "The first name of the customer")]
        public string FirstName { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "Willems", Description = "The last name of the customer")]
        public string LastName { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "marcowillems@gmail.com", Description = "The email of the customer")]
        public string Email { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "50000.00", Description = "The annual income of the customer")]
        public double AnnualIncome { get; set; }
    }
}
