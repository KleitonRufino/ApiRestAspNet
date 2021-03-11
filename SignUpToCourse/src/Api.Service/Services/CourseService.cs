using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Course;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Course;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class CourseService : ICourseService
    {
        private IRepository<CourseEntity> _repository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<CourseEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CourseDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CourseDto>(entity);
        }

        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(listEntity);
        }

        public async Task<CourseDtoCreateResult> Post(CourseDtoCreate Course)
        {
            var model = _mapper.Map<CourseModel>(Course);
            var entity = _mapper.Map<CourseEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CourseDtoCreateResult>(result);
        }

        public async Task<CourseDtoUpdateResult> Put(CourseDtoUpdate Course)
        {
            var model = _mapper.Map<CourseModel>(Course);
            var entity = _mapper.Map<CourseEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CourseDtoUpdateResult>(result);
        }
    }
}
