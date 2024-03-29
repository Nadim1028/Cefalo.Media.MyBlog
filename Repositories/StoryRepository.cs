﻿using Database.Models;
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

        public async Task<IEnumerable<Story>> GetStories(PaginationFilter validFilter)
        {
            //var pagedData = await context.Customers
            //.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            //.Take(validFilter.PageSize)
            //.ToListAsync();

            //var stories = await databaseContext.StoryTable.OrderBy(story => story.StoryTitle).ToListAsync();
            var stories = await databaseContext.StoryTable.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).
                OrderBy(story => story.PublishedDate).ToListAsync();
           
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
