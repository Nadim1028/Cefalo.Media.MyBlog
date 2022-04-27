using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStoryRepository
    {
        Task<bool> InsertStory(Story story);
        Task<IEnumerable<Story>>  GetStories(PaginationFilter validFilter);
        Task<Story> GetStoryByID(int storyId);
        Task<bool> DeleteStory(int storyId);
        Task<bool> UpdateStory(Story story);
    }
}
