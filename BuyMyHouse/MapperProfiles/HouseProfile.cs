using AutoMapper;
using BuyMyHouse.Models;
using BuyMyHouse.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.MapperProfiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseResponse>();
        }
    }
}
