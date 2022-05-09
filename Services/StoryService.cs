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
        GetStoryDto dto;
        List<GetStoryDto> listStories = new();


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

        public async Task<IEnumerable<GetStoryDto>> GetStories( )
        {
            //config = new MapperConfiguration(cfg => cfg.CreateMap<Story, StoryDTO>());
            //mapper = config.CreateMapper();

            IEnumerable<Story> stories = await repository.GetAllStories();

            foreach (Story s in stories)
            {
                dto = mapper.Map<GetStoryDto>(s);
                listStories.Add(dto);
            }

            IEnumerable<GetStoryDto> dtoStories = listStories;

            return dtoStories;
        }


        public async Task<PaginationToReturnDto> GetPaginatedStories(StoryParamDto storyParamDto)
        {
            var pageNumber = storyParamDto.PageNumber;
            var pageSize = storyParamDto.PageSize;

            var stories =(storyParamDto.AuthorId >0)
                ? await repository.GetStoriesByAuthor(pageNumber, pageSize, storyParamDto.AuthorId) : 
                await repository.GetStories(pageNumber, pageSize) ;

            // var storiesDto = _mapper.Map<IEnumerable<StoryToReturnDto>>(stories);

            var storiesDto = new List<GetStoryDto>();

            foreach (var story in stories)
            {
                var storyDto = new GetStoryDto
                {
                    StoryId = story.StoryId,
                    AuthorId = story.AuthorId,
                    StoryBody = story.StoryBody,
                    PublishedDate = story.PublishedDate,
                    StoryTitle = story.StoryTitle
                };

                storiesDto.Add(storyDto);
            }

            var totalStories = (storyParamDto.AuthorId > 0)
                ? await repository.GetTotalStoriesByAuthor(storyParamDto.AuthorId)
                : await repository.GetTotalStories() ; 

            var totalPages = (int)Math.Ceiling((decimal)totalStories / pageSize);

            return new PaginationToReturnDto
            {
                Data = storiesDto,
                Count = totalStories,
                TotalPage = totalPages,
                CurrentPage = pageNumber
            };
        }

        public async Task<object> GetPaginatedSearchedStories(SearchingDto searchingDto)
        {
            if (String.IsNullOrEmpty(searchingDto.SearchString) ||
                String.IsNullOrWhiteSpace(searchingDto.SearchString))
            {
                return new PaginationToReturnDto
                {
                    Data = Array.Empty<GetStoryDto>(),
                    Count = 0,
                    TotalPage = 0,
                    CurrentPage = 1
                };
            }

            var pageNumber = searchingDto.PageNumber;
            var pageSize = searchingDto.PageSize;

            var stories =
                await repository.GetStoriesBySearch(pageNumber, pageSize, searchingDto.SearchString);

            var storiesDto = new List<GetStoryDto>();

            foreach (var story in stories)
            {
                var storyDto = new GetStoryDto
                {
                    StoryId = story.StoryId,
                    AuthorId = story.AuthorId,
                    StoryBody = story.StoryBody,
                    PublishedDate = story.PublishedDate,
                    StoryTitle = story.StoryTitle
                };

                storiesDto.Add(storyDto);
            }

            var totalStories = await repository.GetTotalStoriesBySearch(searchingDto.SearchString);

            var totalPages = (int)Math.Ceiling((decimal)totalStories / pageSize);

            return new PaginationToReturnDto
            {
                Data = storiesDto,
                Count = totalStories,
                TotalPage = totalPages,
                CurrentPage = pageNumber
            };
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
