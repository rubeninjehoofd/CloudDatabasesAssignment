using System.Net;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace BuyMyHouse.API
{
    public class MortgagesController
    {
        private readonly ILogger _logger;

        public MortgagesController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MortgagesController>();
        }

        [Function("GetMortageById")]
        [OpenApiOperation(operationId: "Get mortgage", tags: new[] { "Get mortgage" }, Summary = "Get a mortgage from a customer", Description = "This endpoint returns the data of a specific mortgage from a user.")]
        [OpenApiParameter(name: "userId", In = ParameterLocation.Path, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(UserResponseDTO), Description = "The OK response"/*, Example = typeof(GetUserExample)*/)]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
