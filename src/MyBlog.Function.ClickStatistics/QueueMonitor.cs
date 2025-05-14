using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MyBlog.Function.ClickStatistics
{
    [StorageAccount("MyBlogStorage")]
    public class QueueMonitor
    {
        [FunctionName("QueueMonitor")]
        [return: Table("ClickBlogStatistics")]
        public ClickBlogStatistics Run(
            [QueueTrigger("click-menu")] string message,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {message}");

            var theParts = message.Split(' ');
            var partitionKey = theParts[0];
            var clickAction = theParts[1];

            return new ClickBlogStatistics
            {
                PartitionKey = partitionKey,
                RowKey = Guid.NewGuid().ToString(),

                ActionCode = clickAction,
                CreatedAt = DateTime.UtcNow
            };

        }
    }

    public class ClickBlogStatistics
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        public string ActionCode { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}