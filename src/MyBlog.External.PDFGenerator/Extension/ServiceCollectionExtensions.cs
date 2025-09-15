using Microsoft.Extensions.DependencyInjection;
using MyBlog.External.PDFGenerator.Interface;
using MyBlog.External.PDFGenerator.Service;
using MyBlog.External.PDFGenerator.Template.MyCV.Model;
using MyBlog.External.PDFGenerator.Template.MyCV.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPdfGenerator(this IServiceCollection services)
        {
            // Register templates
            services.AddSingleton<IPdfTemplate<MyCVPdfModel>, MyCVTemplate>();

            // Configure templates
            services.AddSingleton<IPdfTemplateService>(provider =>
            {
                var templateService = new PdfTemplateService();
                var nyCVTemplate = provider.GetRequiredService<IPdfTemplate<MyCVPdfModel>>();

                templateService.RegisterTemplate(nyCVTemplate);

                return templateService;
            });

            return services;
        }
    }
}
