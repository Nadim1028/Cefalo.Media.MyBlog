﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    
    public class Author
    {
        public int AuthorId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        //nav prop
        public ICollection<Story> Stories { get; set; }

        
    }
}
