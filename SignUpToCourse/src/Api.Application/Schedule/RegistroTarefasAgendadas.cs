using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.SignUpToCourse;
using Api.Domain.Interfaces.Services.SignUpToCourse;
using FluentScheduler;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Schedule
{
public class RegistroTarefasAgendadas : Registry
{

   public RegistroTarefasAgendadas()
   {

       
   }


   public async Task processSignUpToCourse(ISignUpToCourseService _service)
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
   }

}