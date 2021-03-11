using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CourseStatisticsImplementation : BaseRepository<CourseStatisticsEntity>, ICourseStatisticsRepository
    {
        private DbSet<CourseStatisticsEntity> _dataset;
        public CourseStatisticsImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CourseStatisticsEntity>();
        }

        public async Task<CourseStatisticsEntity> FindByCourseId(string courseId)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.CourseId.Equals(courseId));
        }
    }
}
