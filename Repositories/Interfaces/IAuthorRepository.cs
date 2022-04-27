using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<bool> InsertAuthor(Author author);
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthorByID(int AuthorId);
        Task<bool> DeleteAuthor(int AuthorId);
        Task<bool> UpdateAuthor(Author author);
        Task<bool> UserExists(string userName);
        Task<Author> GetAuthorByUserName(string userName);
    }
}
