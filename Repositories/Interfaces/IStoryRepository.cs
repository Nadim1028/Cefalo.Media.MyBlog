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
        Task<IEnumerable<Story>> GetStories(int pageNumber, int pageSize);
        Task<IEnumerable<Story>> GetAllStories();
        Task<Story> GetStoryByID(int storyId);
        Task<bool> DeleteStory(int storyId);
        Task<bool> UpdateStory(Story story);
        Task<IEnumerable<Story>> GetStoriesBySearch(int pageNumber, int pageSize, string searchString);
        Task<int> GetTotalStoriesBySearch(string searchString);
        Task<IEnumerable<Story>> GetStoriesByAuthor(int pageNumber, int pageSize, int authorId);
        Task<int> GetTotalStoriesByAuthor(int authorId);
        Task<int> GetTotalStories();
    }
}
