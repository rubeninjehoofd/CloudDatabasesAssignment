using System.Net;
using AutoMapper;
using BuyMyHouse.Models;
using BuyMyHouse.Models.DTO;
using BuyMyHouse.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BuyMyHouse.API
{
    public class MortgagesController
    {
        private readonly ILogger _logger;
        private readonly IMortgageService _mortgageService;
        private readonly IMapper _mapper;

        public MortgagesController(ILoggerFactory loggerFactory, IMortgageService mortgageService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<MortgagesController>();
            _mortgageService = mortgageService ?? throw new ArgumentNullException(nameof(mortgageService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("GetMortageByCustomer")]
        [OpenApiOperation(operationId: "Get mortgage", tags: new[] { "Get mortgage" }, Summary = "Get a mortgage from a customer", Description = "This endpoint returns the data of a specific mortgage from a user.")]
        [OpenApiParameter(name: "customerId", In = ParameterLocation.Path, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(MortgageResponse), Description = "The OK response")]
        public async Task<HttpResponseData> GetMortgageByCustomer([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mortgages/{customerId:Guid}")] HttpRequestData req, Guid customerId)
        {
            HttpResponseData response = req.CreateResponse();

            try
            {
                Mortgage mortgage = await _mortgageService.GetMortgageByCustomer(customerId);

                MortgageResponse mapperMortgage = _mapper.Map<MortgageResponse>(mortgage);

                await response.WriteAsJsonAsync(mapperMortgage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await response.WriteAsJsonAsync(ex.Message, HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
