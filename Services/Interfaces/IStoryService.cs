using Database.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStoryService
    {
        Task<bool> InsertStory(StoryDTO story);
        Task<IEnumerable<StoryDTO>> GetStories();
        Task<Story> GetStoryByID(int storyId);
        Task<bool> DeleteStory(int studentID);
        Task<bool> UpdateStory(StoryDTO story);
    }
}
