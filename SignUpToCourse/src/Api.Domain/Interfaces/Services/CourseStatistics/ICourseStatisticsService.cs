using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CourseStatistics;

namespace Api.Domain.Interfaces.Services.CourseStatistics
{
    public interface ICourseStatisticsService
    {
        Task<CourseStatisticsDto> Get(Guid id);
        Task<IEnumerable<CourseStatisticsDto>> GetAll();
        Task<CourseStatisticsDtoCreateResult> Post(CourseStatisticsDtoCreate course);
        Task<CourseStatisticsDtoUpdateResult> Put(CourseStatisticsDtoUpdate course);
        Task<bool> Delete(Guid id);
        Task<CourseStatisticsDto> FindByCourseId(string courseId);
        
    }
}
