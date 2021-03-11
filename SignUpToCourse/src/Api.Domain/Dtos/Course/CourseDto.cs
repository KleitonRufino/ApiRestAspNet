using System;

namespace Api.Domain.Dtos.Course
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
