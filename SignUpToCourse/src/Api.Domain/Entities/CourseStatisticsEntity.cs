using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CourseStatisticsEntity : BaseEntity
    {

        [Required]
        public string CourseId {get; set;}
        [Required]
        public int MinimumAge { get; set; }
        [Required]
        public int MaximumAge { get; set; }
        [Required]
        public decimal AverageAge { get; set; }
    }
}
