using MyBlog.Service.Shared.Interfaces.AI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.AI
{
    public interface IAIModelService
    {
        Task<List<AIModel>> GetAllModelsAsync();
        Task<List<AIModel>> GetAllEnableModelsAsync();
        Task<AIModel?> GetDefaultModel(string? modelCode);
    }
}
