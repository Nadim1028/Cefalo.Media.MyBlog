using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cefalo.Media.MyBlog.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]

    public class StoryController : Controller
    {
        private readonly IStoryService storyService;
        


        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateStory([FromBody] StoryDTO storyDTO)
        {
            await storyService.InsertStory(storyDTO);
            return Created("", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryDTO>>> GetAllStories()
        {
            
            IEnumerable<StoryDTO> stories =  await storyService.GetStories();
            return Ok(stories);
        }

        [HttpPut]
        [Consumes("application/xml")]
        public async Task<IActionResult> UpdateStory([FromBody] StoryDTO storyDTO)
        {
            await storyService.UpdateStory(storyDTO);
            return Ok(true);
        }

    }
}
