using MyBlog.External.PDFGenerator.Interface;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Template.Core
{
    public abstract class BaseTemplate<TModel> : IPdfTemplate<TModel>
    {
        public abstract string TemplateName { get; }

        public virtual byte[] Generate(TModel model)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                BuildDocument(container, model);
            });

            return document.GeneratePdf();
        }

        protected virtual void BuildDocument(IDocumentContainer container, TModel model)
        {
            container.Page(page =>
            {
                ConfigurePage(page);

                if (HasHeader(model))
                {
                    page.Header().Element(c => BuildHeader(c, model));
                }

                page.Content().Element(c => BuildContent(c, model));

                if (HasFooter(model))
                {
                    page.Footer().Element(c => BuildFooter(c, model));
                }
            });
        }

        protected virtual void ConfigurePage(PageDescriptor page)
        {
            page.Size(PageSizes.Letter);
            page.Margin(0.2f, Unit.Inch);
        }

        protected virtual bool HasHeader(TModel model) => true;
        protected virtual bool HasFooter(TModel model) => true;

        protected abstract void BuildHeader(IContainer container, TModel model);
        protected abstract void BuildContent(IContainer container, TModel model);
        protected abstract void BuildFooter(IContainer container, TModel model);
    }
}
