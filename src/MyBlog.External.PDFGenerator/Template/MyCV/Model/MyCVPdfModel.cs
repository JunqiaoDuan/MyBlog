using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.External.PDFGenerator.Template.MyCV.Model
{
    public class MyCVPdfModel
    {

        #region Base Info

        public string? Name { get; set; }
        public byte[]? Avatar { get; set; }

        public string? GitHub { get; set; }
        public string? Discord { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? Skills { get; set; }

        #endregion

        #region Patient Info

        public List<MyCVPdfModel_Project> DataList_Project = [];

        #endregion
    }

    public class MyCVPdfModel_Project
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public string? UrlGitHub { get; set; }
    }

}
