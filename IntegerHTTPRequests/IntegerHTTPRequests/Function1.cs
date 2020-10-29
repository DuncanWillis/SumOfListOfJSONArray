using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.Extensions.Options;

namespace FunctionApp1Practice
{
    public static class SumOfIntegers
    {
        [FunctionName("SumOfIntegers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var list = JsonConvert.DeserializeObject<List<int>>(requestBody);

            log.LogInformation($"{requestBody}");

            string stringSum = list.Sum().ToString();

            log.LogInformation($"{stringSum}");

            return new OkResult();
        }

    }

}
