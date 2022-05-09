using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.StoryDto
{
    public  class StoryParamDto : PaginationFilter
    {
        public int AuthorId { get; set; }
    }
}
