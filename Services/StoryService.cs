using Database.Models;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StoryService : IStoryService
    {
        private IStoryRepository repository;

        //public StoryService()
        //{
        //    repository = new StoryRepository(new ApplicationContext());
        //}

        public StoryService(IStoryRepository storyRepository)
        {
            repository = storyRepository;
        }


        public async Task<bool> InsertStory(Story story)
        {
            await repository.InsertStory(story);
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
