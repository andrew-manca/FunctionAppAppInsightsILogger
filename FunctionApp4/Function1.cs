using System;
using System.IO;
using System.Threading.Tasks;
using FunctionApp4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyNamespace
{
    public class Function1
    {
        private ITestInterfaceLogging Logging;

        public Function1(ITestInterfaceLogging testInterface )
        {
            Logging = testInterface;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            Logging.logStuff();


            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            log.LogInformation(new EventId((int)LoggingConstants.EventId.SubmissionSucceeded),
                           LoggingConstants.Template,
                           LoggingConstants.EventId.SubmissionSucceeded.ToString(),
                           LoggingConstants.EntityType.Order.ToString(),
                           name,
                           LoggingConstants.Status.Succeeded.ToString(),
                           Guid.NewGuid().ToString(),
                           LoggingConstants.CheckPoint.Publisher.ToString(),
                           "");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}   