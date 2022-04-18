using AutoMapper;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Cefalo.Media.MyBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryService storyService;
        private readonly IMapper mapper;

        public StoryController(IStoryService storyService, IMapper mapper)
        {
            this.storyService = storyService;
            this.mapper = mapper;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateStory([FromBody] Story story)
        {
            await storyService.InsertStory(story);
            return Ok(200);
        }

    }
}
