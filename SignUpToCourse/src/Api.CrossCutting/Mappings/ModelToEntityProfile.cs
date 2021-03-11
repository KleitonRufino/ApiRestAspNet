using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {

           CreateMap<CourseModel, CourseEntity>()
           .ReverseMap();

            CreateMap<SignUpToCourseModel, SignUpToCourseEntity>()
           .ReverseMap();

            CreateMap<CourseStatisticsModel, CourseStatisticsEntity>()
           .ReverseMap();

        }
    }
}
