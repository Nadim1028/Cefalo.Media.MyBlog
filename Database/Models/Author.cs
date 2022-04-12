﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Addresss { get; set; }

        //nav prop
        public ICollection<Story> Stories { get; set; }
    }
}
