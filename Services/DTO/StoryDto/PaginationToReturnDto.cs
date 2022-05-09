using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.StoryDto
{
    public  class PaginationToReturnDto
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<GetStoryDto> Data { get; set; }
    }
}
