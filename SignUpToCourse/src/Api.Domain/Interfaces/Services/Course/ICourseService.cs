using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Course;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Course
{
    public interface ICourseService
    {
        Task<CourseDto> Get(Guid id);
        Task<IEnumerable<CourseDto>> GetAll();
        Task<CourseDtoCreateResult> Post(CourseDtoCreate course);
        Task<CourseDtoUpdateResult> Put(CourseDtoUpdate course);
        Task<bool> Delete(Guid id);
    }
}
