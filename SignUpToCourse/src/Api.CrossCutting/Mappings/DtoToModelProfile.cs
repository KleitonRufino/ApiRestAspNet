using Api.Domain.Dtos.Course;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Dtos.CourseStatistics;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {

            #region Course
            CreateMap<CourseModel, CourseDto>()
            .ReverseMap();
            CreateMap<CourseModel, CourseDtoCreate>()
            .ReverseMap();
            CreateMap<CourseModel, CourseDtoUpdate>()
            .ReverseMap();
            #endregion

            #region SignUpToCourse
            CreateMap<SignUpToCourseModel, SignUpToCourseDto>()
            .ReverseMap();
            CreateMap<SignUpToCourseModel, SignUpToCourseDtoCreate>()
            .ReverseMap();
            CreateMap<SignUpToCourseModel, SignUpToCourseDtoUpdate>()
            .ReverseMap();
            #endregion

            #region CourseStatistics
            CreateMap<CourseStatisticsModel,CourseStatisticsDto>()
            .ReverseMap();
            CreateMap<CourseStatisticsModel, CourseStatisticsDtoCreate>()
            .ReverseMap();
            CreateMap<CourseStatisticsModel, CourseStatisticsDtoUpdate>()
            .ReverseMap();
            #endregion

        }

    }
}
