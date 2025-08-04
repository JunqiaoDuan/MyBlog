using MyBlog.Service.Shared.Interfaces.AI;
using MyBlog.Service.Shared.Interfaces.AI.Model;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.ExternalService.AI.OpenAI
{
    public class OpenAIService : IAIService
    {
        private AIServiceContext _context;
        public OpenAIService(AIServiceContext context)
        {
            _context = context;
        }

        public void Test()
        {
            var _secretKey = _context.SecretKey;
            var _endpoint = _context.EndPoint;

            var chatClient = new ChatClient(
              "gpt-4.1",
              new ApiKeyCredential(_secretKey),
              new OpenAIClientOptions
              {
                  Endpoint = new Uri(_endpoint),
              }
            );

            ChatCompletion completion = chatClient.CompleteChat("Say 'this is a test.'");

            Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

        }
    }
}
