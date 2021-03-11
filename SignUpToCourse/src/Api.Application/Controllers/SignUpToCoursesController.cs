using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Schedule;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.SignUpToCourse;
using FluentScheduler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    //http://localhost:5000/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpToCoursesController : ControllerBase
    {
        public ISignUpToCourseService _service { get; set; }

        public RegistroTarefasAgendadas _registroTarefasAgendadas;
        public SignUpToCoursesController(ISignUpToCourseService service)
        {
            _service = service;
          JobManager.Initialize();
            JobManager.AddJob(
                async () => await new RegistroTarefasAgendadas().processSignUpToCourse(_service),
            s => s.ToRunEvery(15).Seconds()
            );
         }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithIdSignUpToCourse")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignUpToCourseDtoCreate course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(course);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithIdSignUpToCourse", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
/*   
        public async Task processSignUpToCourse()
   {
    var courses = simulateReadRequestFromFile();
   var emails = new List<Email>();

     foreach (var course in courses)
     {
          try
            {
                var result = await _service.Post(course);
                if (result != null)
                {
                    emails.Add(new Email(){
                        email = result.StudentEmail,
                        content = "Sua inscricao foi realizado com sucesso"
                    });
                }
            }
            catch (ArgumentException)
            {
               
            }
             sendEmail(emails);
     }
    
   }
         public  List<SignUpToCourseDtoCreate> simulateReadRequestFromFile()
    {
        List<SignUpToCourseDtoCreate> list = new List<SignUpToCourseDtoCreate>();
        list.Add(new SignUpToCourseDtoCreate(){
            CourseId = "ef256aac-2b6e-48e5-a598-814a1e468b65",
            StudentName = "Fulano",
            StudentAge = 20,
            StudentEmail = "fulano@email.com"
        });
        return list;
    }

    public void sendEmail(List<Email> emails)
    {
        emails.ForEach(e => Console.WriteLine(e.ToString()));
    }

    public class Email {
        public string email {get; set; }
        public string content {get; set;}
    }

     [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SignUpToCourseDtoUpdate course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(course);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }*/
    }
}
