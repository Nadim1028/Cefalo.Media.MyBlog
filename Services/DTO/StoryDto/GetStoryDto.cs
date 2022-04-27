using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.StoryDto
{
    public class GetStoryDto
    {
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryBody { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }

    }
}
