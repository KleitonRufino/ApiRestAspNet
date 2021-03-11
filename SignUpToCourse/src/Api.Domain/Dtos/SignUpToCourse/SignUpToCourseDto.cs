using System;

namespace Api.Domain.Dtos.SignUpToCourse
{
    public class SignUpToCourseDto
    {
        public Guid Id { get; set; }
        public string CourseId {get; set;}
        public string StudentEmail {get; set;}
        public string StudentName {get; set;}
        public int StudentAge {get; set;}
    }
}
