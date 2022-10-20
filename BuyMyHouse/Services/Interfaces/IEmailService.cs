using BuyMyHouse.Models;

namespace BuyMyHouse.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendMailToAll();
        public Task SendMail(Customer customer);
    }
}
