using System;

namespace Api.Domain.Dtos.CourseStatistics
{
    public class CourseStatisticsDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string CourseId { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public decimal AverageAge { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
