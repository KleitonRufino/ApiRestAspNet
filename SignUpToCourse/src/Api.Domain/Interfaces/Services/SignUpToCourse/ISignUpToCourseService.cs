using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.SignUpToCourse
{
    public interface ISignUpToCourseService
    {
        Task<SignUpToCourseDto> Get(Guid id);
        Task<IEnumerable<SignUpToCourseDto>> GetAll();
        Task<SignUpToCourseDtoCreateResult> Post(SignUpToCourseDtoCreate course);
        Task<SignUpToCourseDtoUpdateResult> Put(SignUpToCourseDtoUpdate course);
        Task<bool> Delete(Guid id);
        
        Task<IEnumerable<SignUpToCourseEntity>> FindByCourseId(string courseId);
    }
}
