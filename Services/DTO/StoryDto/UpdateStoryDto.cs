using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.StoryDto
{
    public class UpdateStoryDto
    {
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryBody { get; set; }
    }
}
