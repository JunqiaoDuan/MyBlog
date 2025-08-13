using MyBlog.Service.Shared.Interfaces.AI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.AI
{
    public interface IAIService
    {
        void Test();
        Task ChatAsync(List<AIChatMessage> messages, string modelCode);
    }
}
