using Api.Domain.Interfaces.Services.Course;
using Api.Domain.Interfaces.Services.SignUpToCourse;
using Api.Domain.Interfaces.Services.CourseStatistics;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICourseService, CourseService>();
            serviceCollection.AddTransient<ISignUpToCourseService, SignUpToCourseService>();
            serviceCollection.AddTransient<ICourseStatisticsService, CourseStatisticsService>();
        }
    }
}
