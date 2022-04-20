using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cefalo.Media.MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly ITokenService tokenService;

        public AuthorController(IAuthorService authorService, ITokenService tokenService)
        {
            this.authorService = authorService;
            this.tokenService = tokenService;
        }
     

        [HttpPost("signup")]
        public async Task<ActionResult<AuthorDTO>> SignUpAuthor(SignUpAuthorDTO signUpAuthorDTO)
        {
            if(await authorService.UserExists(signUpAuthorDTO))
            {
                return BadRequest("UserName is already taken!");
            }
           var author =  await authorService.SignUpAuthor(signUpAuthorDTO);

            if (author == null)
            {
                return StatusCode(500);
            }

            var token = tokenService.CreateToken(author);

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Token = token,
                UserName = author.UserName
            };

           // return Created("",null);
        }

        [HttpPost("signin")]

        public async Task<ActionResult<AuthorDTO>> SignInAuthor(SignInAuthorDTO signInAuthorDTO)
        {
          

            var author = await authorService.SignInAuthor(signInAuthorDTO);

            if (author == null)
                return Unauthorized("Invalid username or password");

            else
                return author;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDTO>>> GetAuthors()
        {
            IEnumerable<GetAuthorDTO>  authors = await authorService.GetAuthors();
            return Ok(authors);
        }


        [HttpGet("{id:int}/{format?}")]

        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await authorService.GetAuthorByID(id);
            return Ok(author);
        }

    }
}
