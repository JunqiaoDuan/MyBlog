using MyBlog.Service.Shared.Interfaces.AI;
using MyBlog.Service.Shared.Interfaces.AI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.ExternalService.AI.Google
{
    public class GeminiService : IAIService
    {
        public void Test()
        {
            Console.WriteLine("Testing Gemini AI Service");
        }

        public Task ChatAsync(List<AIChatMessage> messages, string modelCode)
        {
            throw new NotImplementedException();
        }

    }
}
