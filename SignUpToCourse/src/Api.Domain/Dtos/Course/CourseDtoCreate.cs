using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Course
{
    public class CourseDtoCreate
    {
        [Required(ErrorMessage = "Name é um campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Capacity é um campo obrigatório")]
        public int Capacity { get; set; }
        
        [Required(ErrorMessage = "NumberOfStudents é um campo obrigatório")]
        public int NumberOfStudents { get; set; }
    }
}
