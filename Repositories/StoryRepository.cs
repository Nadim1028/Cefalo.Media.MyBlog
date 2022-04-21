using Database.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationContext databaseContext ;

        public StoryRepository(ApplicationContext applicationContext)
        {
            databaseContext = applicationContext;
        }

        public async Task<bool> InsertStory(Story story)
        {
          await databaseContext.StoryTable.AddAsync(story);
          databaseContext.SaveChanges();
          return true;
        }

        public async Task<IEnumerable<Story>> GetStories()
        {
            var stories = await databaseContext.StoryTable.OrderBy(story => story.StoryTitle).ToListAsync();

            foreach(var story in stories)
            {
               databaseContext.Entry(story).Reference(s => s.Author).Load();
            }
           
            return stories;
        }

        public async Task<bool> UpdateStory(Story story)
        {
           databaseContext.StoryTable.Update(story);
           return await databaseContext.SaveChangesAsync() >=0;
        }

        public Task<Story> GetStoryByID(int storyId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteStory(Story story)
        {
             databaseContext.StoryTable.Remove(story);
            return await databaseContext.SaveChangesAsync() >= 0;
        }
    }
}
