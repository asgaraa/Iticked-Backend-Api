using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Slider;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SliderService:ISliderService
    {
        private readonly ISliderRepository _repository;
        private readonly IMapper _mapper;
        public SliderService(ISliderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SliderDto sliderDto)
        {
            var model = _mapper.Map<Slider>(sliderDto);
            await _repository.CreateAsync(model);

        }

        public async Task<List<SliderDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<SliderDto>>(model);
            return res;
        }
    }
}
