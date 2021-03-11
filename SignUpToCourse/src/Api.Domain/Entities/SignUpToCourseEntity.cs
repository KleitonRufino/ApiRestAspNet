using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class SignUpToCourseEntity : BaseEntity
    {

        [Required]
        public string CourseId {get; set;}

        [Required]
        public string StudentEmail {get; set;}
        
        [Required]
        public string StudentName {get; set;}
        
         [Required]
        public int StudentAge{get; set;}
    }
}
