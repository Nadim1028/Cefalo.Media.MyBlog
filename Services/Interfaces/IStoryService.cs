using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStoryService
    {
        Task<bool> InsertStory(Story story);
        Task<IEnumerable<Story>> GetStories();
        Task<Story> GetStoryByID(int storyId);
        Task<bool> DeleteStudent(int studentID);
        Task<bool> UpdateStudent(Story story);
    }
}
