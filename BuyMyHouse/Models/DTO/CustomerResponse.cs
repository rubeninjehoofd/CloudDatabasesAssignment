
namespace BuyMyHouse.Models.DTO
{
    public class CustomerResponse
    { 
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public double AnnualIncome { get; set; }
    }
}
