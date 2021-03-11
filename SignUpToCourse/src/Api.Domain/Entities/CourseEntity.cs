using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CourseEntity : BaseEntity
    {

        [Required]
        public string Name {get; set;}
        [Required]
        public int Capacity { get; set; }

        [Required]
        public int NumberOfStudents { get; set; }

    }
}
