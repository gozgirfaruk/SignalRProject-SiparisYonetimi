using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.SocialMediaDtos
{
    public class ResultMediaDto
    {
        public int SocialMediaID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
