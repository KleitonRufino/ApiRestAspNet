using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Course;
using Moq;
using Xunit;

namespace Api.Service.Test.Courses
{
    public class QuandoForExecutadoCreate : CourseTestes
    {
        private ICourseService _service;
        private Mock<ICourseService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.Post(CourseDtoCreate)).ReturnsAsync(CourseDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(CourseDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NameCourse, result.Name);
        }
    }
}
