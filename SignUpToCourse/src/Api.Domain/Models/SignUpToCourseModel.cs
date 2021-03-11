using System;

namespace Api.Domain.Models
{
    public class SignUpToCourseModel : BaseModel
    {
        private string _courseId;
        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }
        private string _studentEmail;
        public string StudentEmail
        {
            get { return _studentEmail; }
            set { _studentEmail = value; }
        }

       private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private int _studentAge;
        public int StudentAge
        {
            get { return _studentAge; }
            set { _studentAge = value; }
        }


    }
}
