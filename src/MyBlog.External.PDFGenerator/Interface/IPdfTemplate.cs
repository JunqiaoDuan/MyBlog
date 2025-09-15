using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Interface
{
    public interface IPdfTemplate<in TModel>
    {
        string TemplateName { get; }
        byte[] Generate(TModel model);
    }
}
