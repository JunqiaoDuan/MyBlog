using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MyBlog.Infrastructure.ExternalInterface;
using MyBlog.Service.Shared.Interfaces.ExternalInterface;

namespace MyBlog.Function.Dida365
{
    public class Dida365Service
    {

        private readonly IYearlyHeatMapService _yearlyHeatMapService;

        public Dida365Service(IYearlyHeatMapService yearlyHeatMapService)
        {
            _yearlyHeatMapService = yearlyHeatMapService;
        }

        [FunctionName("Dida365Service")]
        public async Task Run(
            [TimerTrigger("0 * * * * *")] TimerInfo myTimer,
            ILogger log)
        {
            log.LogInformation(
                $"C# Timer trigger function executed at: {DateTime.Now}"
            );

            await _yearlyHeatMapService.ScrapeAndSaveToDbAsync();

            log.LogInformation(
                $"C# Timer trigger function executed compeletely at: {DateTime.Now}"
            );
        }
    }
}
