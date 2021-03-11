using System;

namespace Api.Domain.Dtos.Course
{
    public class CourseDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
         public DateTime CreateAt { get; set; }
    }
}
