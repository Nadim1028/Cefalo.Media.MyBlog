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
        


        public async Task<IEnumerable<Story>> GetStoriesBySearch(int pageNumber, int pageSize, string searchString)
        {
            int numericValue;
            DateTime dateTime;

            bool isNum = int.TryParse(searchString, out numericValue);
            bool isDateTime = DateTime.TryParse(searchString, out dateTime);

            return await databaseContext.StoryTable
                .Where(
                    story =>
                        (isNum? story.AuthorId.Equals(numericValue) : false) || //Convert.ToInt32(searchString)
                        (isNum ? story.StoryId.Equals(numericValue) : false) ||// story.StoryId.Equals(searchString) ||
                        story.StoryTitle.Contains(searchString) ||
                        story.StoryBody.Contains(searchString) ||
                         (isDateTime ? story.PublishedDate.Equals(dateTime) : false) ||
                        story.Author.UserName.Contains(searchString) 
                )
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(story => story.Author)
                .ToListAsync();
        }



        public async Task<int> GetTotalStoriesBySearch(string searchString)
        {

            int numericValue;
            DateTime dateTime;
            bool isNum = int.TryParse(searchString, out numericValue);
            bool isDateTime = DateTime.TryParse(searchString, out dateTime);

            return await databaseContext.StoryTable
                .Where(
                    story =>
                        (isNum ? story.AuthorId.Equals(numericValue) : false) ||
                         (isNum ? story.StoryId.Equals(numericValue) : false) ||
                        story.StoryTitle.Contains(searchString) ||
                        story.StoryBody.Contains(searchString) ||  (isDateTime ? story.PublishedDate.Equals(dateTime ) : false) ||
                        story.Author.UserName.Contains(searchString)
                )
                .CountAsync();
        }


        public async Task<IEnumerable<Story>> GetStoriesByAuthor(int pageNumber, int pageSize, int authorId)
        {
            return await databaseContext.StoryTable
                .Where(story => story.AuthorId == authorId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(story => story.Author)
                .ToListAsync();
        }

        public async Task<int> GetTotalStoriesByAuthor(int authorId)
        {
            return await databaseContext.StoryTable
                .Where(story => story.AuthorId == authorId)
                .CountAsync();
        }

        public async Task<int> GetTotalStories()
        {
            return await databaseContext.StoryTable.CountAsync();
        }


        public async Task<IEnumerable<Story>> GetAllStories()
        {
            var stories = await databaseContext.StoryTable.OrderBy(story => story.StoryTitle).ToListAsync();

            foreach (var story in stories)
            {
                databaseContext.Entry(story).Reference(s => s.Author).Load();
            }

            return stories;
        }
        public async Task<IEnumerable<Story>> GetStories(int pageNumber, int pageSize)
        {
         

           //var stories = await databaseContext.StoryTable.OrderBy(story => story.StoryTitle).ToListAsync();
            var stories = await databaseContext.StoryTable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(story => story.PublishedDate)
                .ToListAsync();
           
            //.Take(validFilter.PageSize)

            foreach (var story in stories)
            {
               databaseContext.Entry(story).Reference(s => s.Author).Load();//explicit loading of navigational prop
            }
           
            return stories;
        }

        public async Task<bool> UpdateStory(Story story)
        {
           databaseContext.StoryTable.Update(story);
           return await databaseContext.SaveChangesAsync() >=0;
        }

        public async Task<Story> GetStoryByID(int storyId)
        {
            //return await _dbContext.Stories  .AsNoTracking() .FirstOrDefaultAsync(story => story.Id == storyId);

            return  await databaseContext.StoryTable.AsNoTracking().FirstOrDefaultAsync(x => x.StoryId == storyId);
        }

        public async Task<bool> DeleteStory(int storyId)
        {
            var story = await GetStoryByID(storyId);
            databaseContext.StoryTable.Remove(story);
            return await databaseContext.SaveChangesAsync() >= 0;
        }
    }
}
