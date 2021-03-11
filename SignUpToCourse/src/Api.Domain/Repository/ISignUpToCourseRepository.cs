using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ISignUpToCourseRepository : IRepository<SignUpToCourseEntity>
    {
        Task<IEnumerable<SignUpToCourseEntity>> FindByCourseId(string courseId);
    }
}
