using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.SignUpToCourse;
using Api.Domain.Models;
using AutoMapper;
using Api.Domain.Interfaces.Services.Course;
using Api.Domain.Dtos.Course;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class SignUpToCourseService : ISignUpToCourseService
    {
        private ISignUpToCourseRepository _repository;
        private ICourseService _courseService;

        private readonly IMapper _mapper;

        public SignUpToCourseService(ISignUpToCourseRepository repository, IMapper mapper, ICourseService courseservice)
        {
            _repository = repository;
            _mapper = mapper;
            _courseService = courseservice;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<SignUpToCourseDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<SignUpToCourseDto>(entity);
        }

        public async Task<IEnumerable<SignUpToCourseDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<SignUpToCourseDto>>(listEntity);
        }

        public async Task<SignUpToCourseDtoCreateResult> Post(SignUpToCourseDtoCreate Course)
        {

            CourseDto courseDto = await _courseService.Get(new Guid(Course.CourseId));
            
            if(courseDto != null)
            {
                if(courseDto.Capacity > courseDto.NumberOfStudents)
               { 
                    var model = _mapper.Map<SignUpToCourseModel>(Course);
                    var entity = _mapper.Map<SignUpToCourseEntity>(model);
                    var result = await _repository.InsertAsync(entity);

                    courseDto.NumberOfStudents = courseDto.NumberOfStudents + 1;
                    await _courseService.Put(new CourseDtoUpdate{
                        Id = courseDto.Id,
                        Capacity = courseDto.Capacity,
                        Name = courseDto.Name,
                        NumberOfStudents = courseDto.NumberOfStudents
                    });
                    return _mapper.Map<SignUpToCourseDtoCreateResult>(result);
                }
                else
                {
                    throw new ArgumentException("Este curso esta com sua capacidade maxima, nao e possivel mais inscrever-se!");
                }
            }
            return null;
        }

        public async Task<SignUpToCourseDtoUpdateResult> Put(SignUpToCourseDtoUpdate Course)
        {
            var model = _mapper.Map<SignUpToCourseModel>(Course);
            var entity = _mapper.Map<SignUpToCourseEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<SignUpToCourseDtoUpdateResult>(result);
        }

        public Task<IEnumerable<SignUpToCourseEntity>> FindByCourseId(string courseId)
        {
            return _repository.FindByCourseId(courseId);
        }
    }
}
