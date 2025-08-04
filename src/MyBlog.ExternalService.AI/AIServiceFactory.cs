using Microsoft.Extensions.DependencyInjection;
using MyBlog.Service.Shared.Interfaces.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.ExternalService.AI
{

    public class AIServiceFactory : IAIServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AIServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAIService GetService(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
            {
                return GetDefaultService();
            }

            return _serviceProvider.GetRequiredKeyedService<IAIService>(providerName);
        }

        public IAIService GetDefaultService()
        {
            return _serviceProvider.GetRequiredService<IAIService>();
        }
    }
}
