using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Course;

namespace Api.Service.Test.Courses
{
    public class CourseTestes
    {
        public static string NameCourse { get; set; }
        public static string NameCourseAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<CourseDto> listaCourseDto = new List<CourseDto>();
        public CourseDto CourseDto;
        public CourseDtoCreate CourseDtoCreate;
        public CourseDtoCreateResult CourseDtoCreateResult;
        public CourseDtoUpdate CourseDtoUpdate;
        public CourseDtoUpdateResult CourseDtoUpdateResult;

        public CourseTestes()
        {
            IdUsuario = Guid.NewGuid();
            NameCourse = Faker.Name.FullName();
            NameCourseAlterado = Faker.Name.FullName();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CourseDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName()
                };
                listaCourseDto.Add(dto);
            }

            CourseDto = new CourseDto
            {
                Id = IdUsuario,
                Name = NameCourse
            };

            CourseDtoCreate = new CourseDtoCreate
            {
                Name = NameCourse
            };


            CourseDtoCreateResult = new CourseDtoCreateResult
            {
                Id = IdUsuario,
                Name = NameCourse,
                CreateAt = DateTime.UtcNow
            };

            CourseDtoUpdate = new CourseDtoUpdate
            {
                Id = IdUsuario,
                Name = NameCourseAlterado
            };

            CourseDtoUpdateResult = new CourseDtoUpdateResult
            {
                Id = IdUsuario,
                Name = NameCourseAlterado,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
