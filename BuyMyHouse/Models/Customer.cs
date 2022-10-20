
using BuyMyHouse.Models.Interfaces;

namespace BuyMyHouse.Models
{
    public class Customer : Entity 
    {
        private const int MONTHS_IN_YEAR = 12;
        private const double INTEREST = 1.06;
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public double AnnualIncome { get; set; }

        public Mortgage? Mortgage { get; set; }

        public long LoanDuration { get; set; }

        public double PurchasePrice { get; set; }

        public double? MaxMortgageWorth
        {
            get
            {
                double calculatedMortgage = PurchasePrice / (LoanDuration * MONTHS_IN_YEAR) + (PurchasePrice * INTEREST / (LoanDuration * MONTHS_IN_YEAR));
                return Math.Round(calculatedMortgage, 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
