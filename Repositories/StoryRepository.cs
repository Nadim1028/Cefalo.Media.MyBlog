using Database.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private ApplicationContext context ;



        public StoryRepository(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }

        public async Task<bool> InsertStory(Story story)
        {
          await context.Stories.AddAsync(story);
          context.SaveChanges();
          return true;
        }

        public Task<bool> DeleteStudent(int studentID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Story>> GetStories()
        {
            throw new NotImplementedException();
        }

        public Task<Story> GetStoryByID(int storyId)
        {
            throw new NotImplementedException();
        }

      

        public Task<bool> UpdateStudent(Story story)
        {
            throw new NotImplementedException();
        }
    }
}
