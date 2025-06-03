using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Dtos.ExternalDto.Dida365
{
    public class Dida365PomodoroHistoryDto
    {
        public int Duration { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Timezone { get; set; } = string.Empty;
    }
}
