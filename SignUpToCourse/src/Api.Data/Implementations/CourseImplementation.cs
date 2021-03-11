using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CourseImplementation : BaseRepository<CourseEntity>, ICourseRepository
    {
        private DbSet<CourseEntity> _dataset;
        public CourseImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CourseEntity>();
        }
    }
}
