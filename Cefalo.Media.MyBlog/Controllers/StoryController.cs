using Database.Models;
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

        [HttpGet("{id:int}/{format?}")]

        public async Task<IActionResult> GetStoryById(int id)
        {
            var story = await storyService.GetStoryByID(id);
            return Ok(story);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStory([FromBody] StoryDTO storyDTO)
        {
            await storyService.UpdateStory(storyDTO);
            return Ok(true);
        }

        [HttpDelete("{id:int}")]

        public async  Task<IActionResult> DeleteStory(int id)
        {
            await storyService.DeleteStory(id);
            return Ok(true);
        }

    }
}
