using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace shafiqjetha.youtubecommenter
{
    public class commentmoderator
    {
        private readonly ILogger<commentmoderator> _logger;

        public commentmoderator(ILogger<commentmoderator> log)
        {
            _logger = log;
        }

        [FunctionName("commentmoderator")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "videoId", "apiKey" })]
        [OpenApiParameter(name: "videoId", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiParameter(name: "apiKey", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The API key for OpenAI")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string apiKey = req.Query["apiKey"];
            string videoId = req.Query["videoId"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            apiKey ??= data?.apiKey;
            videoId ??= data?.videoId;

            string responseMessage = string.IsNullOrEmpty(videoId)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Your YouTube video ID is {videoId} and your OpenAI API Key is {apiKey} This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}

