using MyBlog.External.PDFGenerator.Const;
using MyBlog.External.PDFGenerator.Template.Core;
using MyBlog.External.PDFGenerator.Template.MyCV.Model;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace MyBlog.External.PDFGenerator.Template.MyCV.Template
{
    public class MyCVTemplate : BaseTemplate<MyCVPdfModel>
    {
        public override string TemplateName => PDFTemplateConst.TemplateName_MyCV;

        protected override void BuildHeader(IContainer container, MyCVPdfModel model)
        {
            container.PaddingVertical(10).Row(row =>
            {
                // Logo section
                row.ConstantItem(232).Column(col =>
                {
                    if (model.Avatar != null)
                    {
                        col.Item().PaddingLeft(104).Image(model.Avatar).FitArea();
                    }
                });

                // Company info section
                row.RelativeItem().Column(col =>
                {
                    col.Item().PaddingTop(20).PaddingLeft(10).Text(model.Name)
                       .FontFamily("Palace Script MT")
                       .FontSize(32);

                    col.Item().PaddingLeft(10).PaddingTop(10).Text(model.Email)
                       .FontFamily("Palace Script MT")
                       .FontSize(26);

                    col.Item().PaddingLeft(10).Text(model.GitHub)
                       .FontFamily("Palace Script MT")
                       .FontSize(26);
                });
            });
        }

        protected override void BuildContent(IContainer container, MyCVPdfModel model)
        {
            container.PaddingVertical(20).PaddingHorizontal(24).Column(content =>
            {
                content.Item().PaddingTop(10);

                #region Date
                content.Item().Text($"Date: {DateTime.Now:MM/dd/yyyy}")
                       .FontFamily("Arial")
                       .FontSize(10)
                       .LineHeight(1.4f);
                #endregion

                content.Item().PaddingTop(20);

                #region Bio
                content.Item().Text(model.Bio)
                       .FontFamily("Arial")
                       .FontSize(10)
                       .LineHeight(1.4f);
                #endregion

                content.Item().PaddingTop(20);

                #region Skills
                if (model.Skills != null)
                {
                    var skillList = model.Skills
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(s => s.Trim())
                                        .Where(s => !string.IsNullOrWhiteSpace(s))
                                        .ToList();

                    foreach (var _skill in skillList)
                    {
                        content.Item().Text(_skill)
                           .FontFamily("Arial")
                           .FontSize(10)
                           .LineHeight(1.4f);
                    }
                }
                #endregion

                content.Item().PaddingTop(20);

                #region Projects
                content.Item().Text("Projects")
                    .FontFamily("Arial")
                    .FontSize(14)
                    .Bold();

                foreach (var _project in model.DataList_Project)
                {
                    // Project image
                    if (_project.Image != null)
                    {
                        content.Item().Image(_project.Image).FitArea();
                    }

                    content.Item().Text(_project.Name)
                        .FontFamily("Arial")
                        .FontSize(12)
                        .Bold();

                    content.Item().Text(_project.Description)
                        .FontFamily("Arial")
                        .FontSize(10)
                        .LineHeight(1.4f);
                }
                #endregion
            });
        }

        protected override void BuildFooter(IContainer container, MyCVPdfModel model)
        {
        }
    }
}
