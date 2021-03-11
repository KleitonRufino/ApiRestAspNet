using System;

namespace Api.Domain.Models
{
    public class CourseModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        private int _numberOfStudents;
        public int NumberOfStudents
        {
            get { return _numberOfStudents; }
            set{ _numberOfStudents = value; }
        }
    }
}
