using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(IUnitOfWork unitOfWork) : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult<Student?>> Get(Guid id)
    {
        Console.WriteLine("hola");
        Student? student = await unitOfWork.StudentRepository.GetByID(id);
        if (student == null)
            return NotFound();

        return student;
    }

}
