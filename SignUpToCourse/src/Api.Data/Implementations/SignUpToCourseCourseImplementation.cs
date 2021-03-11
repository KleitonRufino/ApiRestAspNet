using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Data.Implementations
{
    public class SignUpToCourseCourseImplementation : BaseRepository<SignUpToCourseEntity>, ISignUpToCourseRepository
    {
        private DbSet<SignUpToCourseEntity> _dataset;
        public SignUpToCourseCourseImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<SignUpToCourseEntity>();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public async Task<IEnumerable<SignUpToCourseEntity>> FindByCourseId(string courseId)
        {
            return await _dataset.Where(c => c.CourseId.Equals(courseId)).ToListAsync();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
