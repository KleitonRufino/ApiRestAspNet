using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CourseStatistics;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.CourseStatistics;
using Api.Domain.Interfaces.Services.SignUpToCourse;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;
using System.Linq;

namespace Api.Service.Services
{
    public class CourseStatisticsService : ICourseStatisticsService
    {
        private ICourseStatisticsRepository _repository;
        private ISignUpToCourseService _signUpToCourseService;

        private readonly IMapper _mapper;

        public CourseStatisticsService(ICourseStatisticsRepository repository, IMapper mapper, ISignUpToCourseService signUpToCourseService)
        {
            _repository = repository;
            _mapper = mapper;
            _signUpToCourseService = signUpToCourseService;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CourseStatisticsDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CourseStatisticsDto>(entity);
        }

        public async Task<IEnumerable<CourseStatisticsDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CourseStatisticsDto>>(listEntity);
        }

        public async Task<CourseStatisticsDtoCreateResult> Post(CourseStatisticsDtoCreate Course)
        {

            var model = _mapper.Map<CourseStatisticsModel>(Course);
            var entity = _mapper.Map<CourseStatisticsEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CourseStatisticsDtoCreateResult>(result);
        }

        private async Task<CourseStatisticsDto> calcularAsync(CourseStatisticsDto statistic)
        {
            IEnumerable<SignUpToCourseEntity> courses = await _signUpToCourseService.FindByCourseId(statistic.CourseId);
            if(courses != null && courses.Count() > 0)
            {
                statistic.AverageAge = Convert.ToDecimal(courses.Average(c => c.StudentAge));
                statistic.MinimumAge = courses.Min(c => c.StudentAge);
                statistic.MaximumAge = courses.Max(c => c.StudentAge);
                
                if(statistic.Id == Guid.Empty)
                {
                    await Post(new CourseStatisticsDtoCreate(){
                        CourseId = statistic.CourseId,
                        MaximumAge = statistic.MaximumAge,
                        MinimumAge = statistic.MinimumAge,
                        AverageAge = statistic.AverageAge
                    });
                }
                else
                {
                     await Put(new CourseStatisticsDtoUpdate(){
                        Id = statistic.Id,
                        CourseId = statistic.CourseId,
                        MaximumAge = statistic.MaximumAge,
                        MinimumAge = statistic.MinimumAge,
                        AverageAge = statistic.AverageAge
                    });   
                }
            }
            return statistic;
        }

        public async Task<CourseStatisticsDtoUpdateResult> Put(CourseStatisticsDtoUpdate Course)
        {
            var model = _mapper.Map<CourseStatisticsModel>(Course);
            var entity = _mapper.Map<CourseStatisticsEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CourseStatisticsDtoUpdateResult>(result);
        }

        public async Task<CourseStatisticsDto> FindByCourseId(string courseId)
        {
           var result = await _repository.FindByCourseId(courseId);
           var statistic = _mapper.Map<CourseStatisticsDto>(result); 
           if(statistic == null)
            {
                statistic =  await calcularAsync(new CourseStatisticsDto(){ CourseId = courseId});
                return statistic;
            }
            if(statistic != null)
            {
                DateTime current = DateTime.UtcNow;
                TimeSpan? diffDates = current - statistic.UpdateAt;
                if(diffDates.Value.Minutes > 1)
                {
                    statistic = await calcularAsync(statistic);
                }
            }
            return statistic;
        }
    }
}
