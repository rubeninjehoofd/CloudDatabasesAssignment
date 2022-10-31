using Microsoft.Extensions.Configuration;

namespace BuyMyHouse.DAL
{
    public class FunctionConfiguration
    {
        public string CosmosAccountEndpoint { get; }
        public string CosmosAccountKey { get; }
        public string CosmosDatabaseName { get; }
        public string SendGridApiKey { get; }
        public string MailSender { get; set; }

        public FunctionConfiguration(IConfiguration config)
        {
            CosmosAccountEndpoint = config["CosmosAccountEndpoint"];
            CosmosAccountKey = config["CosmosAccountKey"];
            CosmosDatabaseName = config["CosmosDatabaseName"];
            SendGridApiKey = config["SendGridApiKey"];
            MailSender = config["MailSender"];
        }
    }
}
