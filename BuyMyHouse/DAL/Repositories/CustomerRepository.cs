using BuyMyHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(BuyHouseContext dbContext) : base(dbContext) { }
    }
}
