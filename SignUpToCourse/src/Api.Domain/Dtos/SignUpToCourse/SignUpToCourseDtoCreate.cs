using System.ComponentModel.DataAnnotations;
using System;

namespace Api.Domain.Dtos.SignUpToCourse
{
    public class SignUpToCourseDtoCreate
    {
   
        [Required(ErrorMessage = "CourseId é um campo obrigatório")]
        public string CourseId {get; set;}
        [Required(ErrorMessage = "StudentEmail é um campo obrigatório")]
        public string StudentEmail {get; set;}
        [Required(ErrorMessage = "StudentName é um campo obrigatório")]
        public string StudentName {get; set;}
        [Required(ErrorMessage = "StudentAge é um campo obrigatório")]
        public int StudentAge {get; set;}
    }
}
