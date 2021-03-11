using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICourseStatisticsRepository : IRepository<CourseStatisticsEntity>
    {
        
        Task<CourseStatisticsEntity> FindByCourseId(string courseId);
    }
}
