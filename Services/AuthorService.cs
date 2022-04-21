using AutoMapper;
using Database.Models;
using Repositories.Interfaces;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository repository;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;


        public AuthorService(IAuthorRepository repository,IMapper mapper, ITokenService tokenService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<GetAuthorDTO> GetAuthorByID(int authorId)
        {
            var author = await repository.GetAuthorByID(authorId);
            GetAuthorDTO getAuthorDto = mapper.Map<GetAuthorDTO>(author);
            return getAuthorDto;
        }

        public async Task<Author> SignUpAuthor(SignUpAuthorDTO signUpAuthorDto)
        {
            var author = mapper.Map<Author>(signUpAuthorDto);
            String hashed = GeneratePasswordHash(author.Password);
            author.Password = hashed;
            await repository.InsertAuthor(author);
            return author;
        }

 
        public async Task<IEnumerable<GetAuthorDTO>> GetAuthors()
        {
            IEnumerable<Author> authors = await repository.GetAuthors();
            GetAuthorDTO dto;
            List<GetAuthorDTO> listOfAuthors = new();

            foreach (Author a in authors)
            {
                 dto = mapper.Map<GetAuthorDTO>(a);
                listOfAuthors.Add(dto);
            }

            IEnumerable<GetAuthorDTO> authorsDto = listOfAuthors;

            return authorsDto;
        }

        public async Task<AuthorDTO> SignInAuthor(SignInAuthorDTO signInAuthorDto)
        {
           // Author author =  mapper.Map<Author>(signInAuthorDto);

            if (await repository.UserExists(signInAuthorDto.UserName)){
                //Author user = await repository.GetUserByUserName(User.UserName);

                var author= await repository.GetAuthorByUserName(signInAuthorDto.UserName);
                var authorDTO = mapper.Map<AuthorDTO>(author);

                var token = tokenService.CreateToken(author);

                if (FindingSimilarityOfHashValue(author.Password, signInAuthorDto.Password))
                    return new AuthorDTO
                    {
                        AuthorId = author.AuthorId,
                        Token = token,
                        UserName = author.UserName
                    };
                //  return authorDTO;
                else 
                    return null;      
            }

            else
            {
                return null;
            }       
        }

        public string GeneratePasswordHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashed = Convert.ToBase64String(hashBytes);
            return hashed;
        }

        public bool FindingSimilarityOfHashValue(string savedPasswordHash, String password)
        {

            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }



        public async Task<bool> UpdateAuthor(UpdateAuthorDTO updateAuthorDto)
      {
            var author = mapper.Map<Author>(updateAuthorDto);
            return await repository.UpdateAuthor(author);
       }

        public async Task<bool> DeleteAuthor(int authorId)
        {
            return await repository.DeleteAuthor(authorId);
        }

        public async Task<bool> UserExists(SignUpAuthorDTO signUpAuthorDTO)
        {
            return await repository.UserExists(signUpAuthorDTO.UserName);
        }

    }
}
