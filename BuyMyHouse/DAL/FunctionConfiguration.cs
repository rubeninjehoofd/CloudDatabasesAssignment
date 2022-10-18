using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL
{
    public class FunctionConfiguration
    {
        public string SqlEndpoint { get; }
        public string SqlAccountKey { get; }
        public string SqlDatabaseName { get; }

        public FunctionConfiguration(IConfiguration config)
        {
            SqlEndpoint = config["SqlEndpoint"];
            SqlAccountKey = config["SqlAccountKey"];
            SqlDatabaseName = config["SqlDatabaseName"];
        }
    }
}
