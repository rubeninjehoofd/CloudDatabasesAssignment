using AutoMapper;
using BuyMyHouse.Models;
using BuyMyHouse.Models.DTO;

namespace BuyMyHouse.MapperProfiles
{
    public class MortgageProfile : Profile
    {
        public MortgageProfile()
        {
            CreateMap<Mortgage, MortgageResponse>();
        }
    }
}
