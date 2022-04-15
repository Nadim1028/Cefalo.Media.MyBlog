﻿using AutoMapper;
using Database.Models;
using Repositories;
using Repositories.Interfaces;
using Services.DTO;
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
        StoryDTO dto;
        List<StoryDTO> listStories = new();


        public StoryService(IStoryRepository storyRepository, IMapper mapper)
        {
            repository = storyRepository;
            this.mapper = mapper;
        }


        public async Task<bool> InsertStory(StoryDTO createStoryDto)
        {
            //config = new MapperConfiguration(cfg => cfg.CreateMap<StoryDTO, Story>());
           // mapper = config.CreateMapper();
            var story = mapper.Map<Story>(createStoryDto);
            return await repository.InsertStory(story);
        }

        public async Task<IEnumerable<StoryDTO>> GetStories()
        {
            //config = new MapperConfiguration(cfg => cfg.CreateMap<Story, StoryDTO>());
            //mapper = config.CreateMapper();

            IEnumerable<Story> stories = await repository.GetStories();
            
            foreach (Story s in stories)
            {
                dto = mapper.Map<StoryDTO>(s);
                listStories.Add(dto);
            }

            IEnumerable<StoryDTO> dtoStories = listStories;

            return dtoStories;
        }

        public Task<Story> GetStoryByID(int storyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudent(Story story)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(int studentID)
        {
            throw new NotImplementedException();
        }

    }
}