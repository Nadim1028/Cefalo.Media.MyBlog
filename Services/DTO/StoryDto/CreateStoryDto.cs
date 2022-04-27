using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.StoryDto
{
    public class CreateStoryDto
    {
        public string StoryTitle { get; set; }
        public string StoryBody { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
