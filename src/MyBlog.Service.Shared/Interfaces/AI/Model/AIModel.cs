using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.AI.Model
{
    public class AIModel
    {
        public AIModel(string code, string dispalyName, bool needAuth, bool enable)
        {
            Code = code;
            DisplayName = dispalyName;
            NeedAuth = needAuth;
            Enable = enable;
        }

        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool NeedAuth { get; set; }
        public bool Enable { get; set; }
    }
}
