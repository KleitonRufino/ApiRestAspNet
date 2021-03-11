using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Course;
using Api.Domain.Interfaces.Services.Course;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Courses {
    public class Retorno_Created
    {
        private CoursesController _controller;
        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICourseService>();
            var nome = Faker.Name.FullName();

            serviceMock.Setup(m => m.Post(It.IsAny<CourseDtoCreate>())).ReturnsAsync(
                new CourseDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome
                }
            );

            _controller = new CoursesController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var CourseDtoCreate = new CourseDtoCreate
            {
                Name = nome
            };

            var result = await _controller.Post(CourseDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CourseDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(CourseDtoCreate.Name, resultValue.Name);


        }
    }
}
