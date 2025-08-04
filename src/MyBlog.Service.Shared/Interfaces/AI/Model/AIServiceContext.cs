using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.AI.Model
{
    public class AIServiceContext
    {
        public string EndPoint { get; set; } = "";
        public string SecretKey { get; set; } = "";
    }
}
