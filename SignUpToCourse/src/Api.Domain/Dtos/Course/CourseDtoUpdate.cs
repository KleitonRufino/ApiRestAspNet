using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Course
{
    public class CourseDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

       [Required(ErrorMessage = "Capacity é um campo obrigatório")]
        public int Capacity { get; set; }
        
        [Required(ErrorMessage = "NumberOfStudents é um campo obrigatório")]
        public int NumberOfStudents { get; set; }
    }
}
