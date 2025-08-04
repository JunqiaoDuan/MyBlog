using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.AI
{
    public interface IAIServiceFactory
    {
        IAIService GetService(string providerName);
        IAIService GetDefaultService();
    }
}
