using BuyMyHouse.DAL;
using BuyMyHouse.DAL.Repositories;
using BuyMyHouse.Models;
using BuyMyHouse.Services;
using BuyMyHouse.Services.Interfaces;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BuyMyHouse
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables()
                .Build();

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureOpenApi()
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(typeof(Program));

                    services.AddSingleton(new FunctionConfiguration(config));
                    services.AddDbContext<BuyHouseContext>();

                    services.AddScoped<IBaseRepository<Customer>, CustomerRepository>();
                    services.AddScoped<IBaseRepository<Mortgage>, MortgageRepository>();
                    services.AddScoped<IMortgageRepository, MortgageRepository>();
                    services.AddScoped<IMortgageService, MortgageService>();
                    services.AddScoped<ICustomerService, CustomerService>(); 
                    services.AddScoped<IEmailService, EmailService>();

                })
                .Build();
            await host.RunAsync();
        }
    }
}