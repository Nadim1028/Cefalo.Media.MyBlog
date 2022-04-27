using AutoMapper;
using Database.Models;
using Repositories;
using Repositories.Interfaces;
using Services.DTO;
using Services.DTO.StoryDto;
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
        private readonly IStoryRepository repository;
        private readonly IMapper mapper;
        UpdateStoryDto dto;
        List<UpdateStoryDto> listStories = new();


        public StoryService(IStoryRepository storyRepository, IMapper mapper)
        {
            repository = storyRepository;
            this.mapper = mapper;
        }


        public async Task<bool> InsertStory(CreateStoryDto createStoryDto, int authorId)
        {
            //config = new MapperConfiguration(cfg => cfg.CreateMap<StoryDTO, Story>());
           // mapper = config.CreateMapper();
            var story = mapper.Map<Story>(createStoryDto);
            story.AuthorId = authorId;
            return await repository.InsertStory(story);
        }

        public async Task<bool> UpdateStory(UpdateStoryDto updateStoryDto,int authorId)
        {
            var searchedStory = await repository.GetStoryByID(updateStoryDto.StoryId);

            if(searchedStory.AuthorId != authorId)
            {
                return false;
            }
            else
            {
                var story = mapper.Map<Story>(updateStoryDto);
                story.AuthorId=authorId;
                return await repository.UpdateStory(story);
            }
            
        }

        public async Task<IEnumerable<UpdateStoryDto>> GetStories()
        {
            //config = new MapperConfiguration(cfg => cfg.CreateMap<Story, StoryDTO>());
            //mapper = config.CreateMapper();

            IEnumerable<Story> stories = await repository.GetStories();
            
            foreach (Story s in stories)
            {
                dto = mapper.Map<UpdateStoryDto>(s);
                listStories.Add(dto);
            }

            IEnumerable<UpdateStoryDto> dtoStories = listStories;

            return dtoStories;
        }

        public async Task<UpdateStoryDto> GetStoryByID(int storyId)
        {
            var story = await repository.GetStoryByID(storyId);
           UpdateStoryDto storyDto = mapper.Map<UpdateStoryDto>(story);
            return storyDto;
        }

        

        public async Task<bool> DeleteStory(int storyId, int authorId)
        {
            var searchedStory = await repository.GetStoryByID(storyId);
            if (searchedStory.AuthorId != authorId)
            {
                return false;
            }
            else
                return await repository.DeleteStory(storyId);

        }

    }
}
