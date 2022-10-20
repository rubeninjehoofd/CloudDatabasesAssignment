using System.Net;
using System.Security.Principal;
using AutoMapper;
using BuyMyHouse.Models;
using BuyMyHouse.Models.DTO;
using BuyMyHouse.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BuyMyHouse.API
{
    public class CustomersController
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ILoggerFactory loggerFactory, ICustomerService customerService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CustomersController>();
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("CreateCustomer")]
        [OpenApiOperation(operationId: "Create customer", tags: new[] { "Create customer" }, Summary = "Create a new customer", Description = "This endpoint allows the creation of a new customer.")]
        [OpenApiRequestBody("application/json", typeof(CreateCustomerDTO), Description = "The customer data."/*, Example = typeof(CreateUserExample)*/)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(CustomerResponse), Description = "The CREATED response")]
        public async Task<HttpResponseData> CreateCustomer([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "customers")] HttpRequestData req)
        {
            HttpResponseData response;

            try
            {
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var createRequest = JsonConvert.DeserializeObject<CreateCustomerDTO>(requestBody);

                var customer = new Customer()
                {
                    FirstName = createRequest.FirstName,
                    LastName = createRequest.LastName,
                    Email = createRequest.Email,
                    AnnualIncome = createRequest.AnnualIncome,
                    LoanDuration = 30,
                    PurchasePrice = 500000.00
                };

                var createdCustomer = await _customerService.Create(customer);

                await _customerService.CalculateMortgages();

                if (createdCustomer is null)
                    response = req.CreateResponse(HttpStatusCode.BadRequest);
                else
                {
                    var mappedCustomer = _mapper.Map<CustomerResponse>(createdCustomer);
                    response = req.CreateResponse(HttpStatusCode.Created);
                    await response.WriteAsJsonAsync(mappedCustomer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Invalid input", ex);
                response = req.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
