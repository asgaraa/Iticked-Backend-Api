using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Hall;
using ServiceLayer.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Slider, SliderEditDto>().ReverseMap();
            CreateMap<Hall, HallDto>().ReverseMap();
            CreateMap<Hall, HallEditDto>().ReverseMap();
        }
    }
}
