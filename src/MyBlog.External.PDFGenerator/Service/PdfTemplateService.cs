using MyBlog.External.PDFGenerator.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Service
{
    public class PdfTemplateService : IPdfTemplateService
    {
        private readonly ConcurrentDictionary<string, object> _templates = new();

        public byte[] GeneratePdf<TModel>(string templateName, TModel model)
        {
            if (!_templates.TryGetValue(templateName, out var template))
            {
                throw new ArgumentException($"Template '{templateName}' not found");
            }

            if (template is IPdfTemplate<TModel> typedTemplate)
            {
                return typedTemplate.Generate(model);
            }

            throw new InvalidOperationException($"Template '{templateName}' does not support model type {typeof(TModel).Name}");
        }

        public async Task GenerateAndSavePdfAsync<TModel>(string templateName, TModel model, string targetFileFullPath)
        {
            var pdfBytes = GeneratePdf(templateName, model);

            if (!targetFileFullPath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                targetFileFullPath += ".pdf";
            }

            await File.WriteAllBytesAsync(targetFileFullPath, pdfBytes);
        }

        public void RegisterTemplate<TModel>(IPdfTemplate<TModel> template)
        {
            _templates[template.TemplateName] = template;
        }

        public IEnumerable<string> GetAvailableTemplates()
        {
            return _templates.Keys;
        }

    }
}
