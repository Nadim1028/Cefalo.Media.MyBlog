using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class GetAuthorDTO
    {
        public int AuthorId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Story> Stories { get; set; }
    }
}
