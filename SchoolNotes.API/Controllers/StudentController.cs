using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : GenericController<Student, Guid>
{

    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
        : base(studentService)
    {
        _studentService = studentService;
    }

    [HttpGet(nameof(GetByCourseSessionID) + "/{courseSessionID}")]
    public async Task<ActionResult<List<Student>>> GetByCourseSessionID(Guid courseSessionID)
    {
        List<Student> students = await _studentService.GetByCourseSessionID(courseSessionID).ToListAsync();
        return Ok(students);
    }


    [HttpGet(nameof(GetByContactDNI) + "/{dni}")]
    public async Task<ActionResult<Student?>> GetByContactDNI(string dni)
    {
        Student? student = await _studentService.GetByContactDNI(dni);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpGet(nameof(SearchByContactDNI) + "/{dni}")]
    public async Task<ActionResult<List<Student>>> SearchByContactDNI(string dni)
    {
        List<Student> students = await _studentService.SearchByContactDNI(dni).ToListAsync();
        return Ok(students);
    }
}
