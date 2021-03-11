using System;

namespace Api.Domain.Dtos.CourseStatistics
{
    public class CourseStatisticsDtoCreate
    {
        public string CourseId { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public decimal AverageAge { get; set; }
    }
}
