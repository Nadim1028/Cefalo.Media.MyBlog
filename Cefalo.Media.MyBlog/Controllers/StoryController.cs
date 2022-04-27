using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.StoryDto;
using Services.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cefalo.Media.MyBlog.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]

    public class StoryController : Controller
    {
        private readonly IStoryService storyService;
        private readonly HttpContext httpContext;


        public StoryController(IStoryService storyService, IHttpContextAccessor httpContextAccessor)
        {
            this.storyService = storyService;
            httpContext = httpContextAccessor.HttpContext;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateStory([FromBody] CreateStoryDto createStoryDto)
        {
            if (createStoryDto == null )
            {
                return BadRequest(500);
            }
            var authorId =int.Parse(httpContext.User.FindFirstValue("AuthorId"));
            await storyService.InsertStory(createStoryDto,authorId);
            return Created("", null);
        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateStory([FromBody] UpdateStoryDto updateStoryDto)
        {
            if (updateStoryDto == null)
            {
                return BadRequest(500);
            }

            var authorId = int.Parse(httpContext.User.FindFirstValue("AuthorId"));
            var value = await storyService.UpdateStory(updateStoryDto,authorId);
            if (value == false)
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record  or Inavlid AuthorId");
                return StatusCode(500, ModelState);
            }
            else
                return Ok(true);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CreateStoryDto>>> GetAllStories()
        {
            
            IEnumerable<UpdateStoryDto> stories =  await storyService.GetStories();
            return Ok(stories);
        }


      

        [HttpGet("{id:int}/{format?}")]
        [Authorize]
        public async Task<IActionResult> GetStoryById(int id)
        {
            var story = await storyService.GetStoryByID(id);
            return Ok(story);
        }


        [HttpDelete("{storyId:int}")]
        [Authorize]
        public async  Task<IActionResult> DeleteStory(int storyId)
        {
            var authorId = int.Parse(httpContext.User.FindFirstValue("AuthorId"));

            var value = await storyService.DeleteStory(storyId, authorId);
            if (value == false)
            {
                ModelState.AddModelError("", $" Inavlid Authorization");
                return StatusCode(500, ModelState);
            }
           else
                return Ok(true);
        }

    }
}
