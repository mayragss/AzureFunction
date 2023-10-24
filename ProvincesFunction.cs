using System.IO;
using System.Net;
using System.Threading.Tasks;
using AzureFunction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Linq;

namespace AzureFunction
{
    public class ProvincesFunction
    {
        private readonly ILogger<ProvincesFunction> _logger;
        private readonly IProvinceService _provinceService;

        public ProvincesFunction(ILogger<ProvincesFunction> log, IProvinceService provinceService)
        {
            _logger = log;
            this._provinceService = provinceService;
        }

        [FunctionName("Get-Provinces-Names")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                var provinces = await _provinceService.GetProvinces();

                return new OkObjectResult(string.Join(", ", provinces.Select((x)=> x.Name)));
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(200);
            }
        }
    }
}

