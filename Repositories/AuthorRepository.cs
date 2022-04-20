using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext databaseContext;
        
        public AuthorRepository(ApplicationContext appContext)
        {
            databaseContext = appContext;
        }


        public async Task<Author> GetAuthorByID(int AuthorId)
        {
            return await databaseContext.AuthorTable.FirstOrDefaultAsync(x => x.AuthorId == AuthorId);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = await databaseContext.AuthorTable.OrderBy(author => author.UserName).ToListAsync();

            foreach (var author in authors)
            {
                databaseContext.Entry(author).Collection(a => a.Stories).Load();
            }
            return authors;
        }

        public async Task<bool> InsertAuthor(Author author)
        {
            await databaseContext.AuthorTable.AddAsync(author);
            databaseContext.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateAuthor(Author author)
        {
            databaseContext.AuthorTable.Update(author);
            return await databaseContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> DeleteAuthor(int AuthorId)
        {
            var author = await GetAuthorByID(AuthorId);
            databaseContext.AuthorTable.Remove(author);
            return await databaseContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await databaseContext.AuthorTable
                .AnyAsync(user => user.UserName == userName);
        }

        public async Task<Author> GetAuthorByUserName(string userName)
        {
            try
            {
                return await databaseContext.AuthorTable.FirstOrDefaultAsync(x => x.UserName == userName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
