using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class StoryDTO
    {
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryBody { get; set; }
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }

       // public int AuthorId { get; set; }
        //  public  AuthorName { get; set; }

        // public Author Author { get; set; }
    }
}
