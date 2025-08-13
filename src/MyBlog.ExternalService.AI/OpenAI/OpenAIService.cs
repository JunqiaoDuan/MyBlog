using MyBlog.ExternalService.AI.Converter;
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
        private OpenAIChatMessageConverter _chatMessageConverter;

        public OpenAIService(AIServiceContext context)
        {
            _context = context;
            _chatMessageConverter = new OpenAIChatMessageConverter();
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

        public async Task ChatAsync(List<AIChatMessage> messages, string modelCode)
        {
            var _secretKey = _context.SecretKey;
            var _endpoint = _context.EndPoint;

            var chatClient = new ChatClient(
              modelCode,
              new ApiKeyCredential(_secretKey),
              new OpenAIClientOptions
              {
                  Endpoint = new Uri(_endpoint),
              }
            );

            var openAIMessges = _chatMessageConverter.ConvertToModelFormat(messages);
            ChatCompletion completion = await chatClient.CompleteChatAsync(openAIMessges);

            var newMessage = completion.Content[0].Text;
            messages.Add(AIChatMessage.CreateAssistantMessage(newMessage));

        }

    }
}
