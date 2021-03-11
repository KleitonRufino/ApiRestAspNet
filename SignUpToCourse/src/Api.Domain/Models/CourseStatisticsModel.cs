using System;

namespace Api.Domain.Models
{
    public class CourseStatisticsModel : BaseModel
    {
        private string _courseId;
        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        private int _minimumAge;
        public int MinimumAge
        {
            get { return _minimumAge; }
            set { _minimumAge = value; }
        }

        private int _maximumAge;
        public int MaximumAge
        {
            get { return _maximumAge; }
            set{ _maximumAge = value; }
        }

        private decimal _averageAge;
        public decimal AverageAge
        {
            get { return _averageAge; }
            set{ _averageAge = value; }
        }
    }
}
