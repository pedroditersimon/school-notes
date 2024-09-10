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
        Student? student = await unitOfWork.StudentRepository.GetByID(id);
        if (student == null)
            return NotFound();

        return student;
    }

    [HttpPost]
    public async Task<ActionResult<Student?>> Create(Student newStudent)
    {
        Student? student = await unitOfWork.StudentRepository.Create(newStudent);
        if (student == null)
            return Conflict();

        bool saved = await unitOfWork.Save();
        if (!saved)
            return Conflict();

        return student;
    }

    [HttpPut]
    public async Task<ActionResult<Student?>> Update(Student newStudent)
    {
        Student? student = await unitOfWork.StudentRepository.Update(newStudent);
        if (student == null)
            return Conflict();

        bool saved = await unitOfWork.Save();
        if (!saved)
            return Conflict();

        return student;
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<Student?>> Delete(Guid id)
    {
        Student? student = await unitOfWork.StudentRepository.GetByID(id);
        if (student == null)
            return NotFound();

        bool deleted = await unitOfWork.StudentRepository.SoftDelete(id);
        if (!deleted)
            return Conflict();

        bool saved = await unitOfWork.Save();
        if (!saved)
            return Conflict();

        return Ok();
    }
}
