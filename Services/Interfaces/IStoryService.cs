using Database.Models;
using Services.DTO;
using Services.DTO.StoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStoryService
    {
        Task<bool> InsertStory(CreateStoryDto story,int authorId);
        Task<IEnumerable<UpdateStoryDto>> GetStories();
        Task<UpdateStoryDto> GetStoryByID(int storyId);
        Task<bool> DeleteStory(int storyId, int authorId);
        Task<bool> UpdateStory(UpdateStoryDto story, int authorId);
    }
}
