using Database.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        //Task<bool> SignUpAuthor(SignUpAuthorDTO signUpAuthorDto);
        Task<Author> SignUpAuthor(SignUpAuthorDTO signUpAuthorDto);
        Task<AuthorDTO> SignInAuthor(SignInAuthorDTO signInAuthorDto);
        Task<IEnumerable<GetAuthorDTO>> GetAuthors();
        Task<GetAuthorDTO> GetAuthorByID(int authorId);
        Task<bool> DeleteAuthor(int authorId);
        Task<bool> UpdateAuthor(UpdateAuthorDTO updateAuthorDto);
        Task<bool> UserExists(SignUpAuthorDTO signUpAuthorDTO);
    }
}
