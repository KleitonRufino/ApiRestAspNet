using Api.Domain.Dtos.Course;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Dtos.CourseStatistics;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {

           CreateMap<CourseDto, CourseEntity>()
           .ReverseMap();
           CreateMap<CourseDtoCreateResult, CourseEntity>()
           .ReverseMap();
           CreateMap<CourseDtoUpdateResult, CourseEntity>()
           .ReverseMap();
           
          CreateMap<SignUpToCourseDto, SignUpToCourseEntity>()
           .ReverseMap();
           CreateMap<SignUpToCourseDtoCreateResult, SignUpToCourseEntity>()
           .ReverseMap();
           CreateMap<SignUpToCourseDtoUpdateResult, SignUpToCourseEntity>()
           .ReverseMap();

            CreateMap<CourseStatisticsDto,CourseStatisticsEntity>()
           .ReverseMap();
           CreateMap<CourseStatisticsDtoCreateResult, CourseStatisticsEntity>()
           .ReverseMap();
           CreateMap<CourseStatisticsDtoUpdateResult, CourseStatisticsEntity>()
           .ReverseMap();
           
        }
    }
}
