using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Interface
{
    public interface IPdfTemplateService
    {
        byte[] GeneratePdf<TModel>(string templateName, TModel model);
        Task GenerateAndSavePdfAsync<TModel>(string templateName, TModel model, string targetFileFullPath);
        void RegisterTemplate<TModel>(IPdfTemplate<TModel> template);
        IEnumerable<string> GetAvailableTemplates();
    }
}
