using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    //[Serializable]
    //[DataContract(IsReference = true)]
    public class Story
    {
        //Title, Body and PublishedDate

        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string StoryBody { get; set; }
        public DateTime PublishedDate { get; set; }

        //foreign key
        public int AuthorId { get; set; }

        //nav prop
        #nullable enable
        public Author?  Author { get; set; }
    }
}
