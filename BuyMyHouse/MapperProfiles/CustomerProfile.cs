using AutoMapper;
using BuyMyHouse.Models;
using BuyMyHouse.Models.DTO;

namespace BuyMyHouse.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
