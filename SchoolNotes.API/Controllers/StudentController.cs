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
        IQueryable<Student> students = _studentService.GetByCourseSessionID(courseSessionID);
        return await students.ToListAsync();
    }


    [HttpGet(nameof(GetByContactDNI) + "/{dni}")]
    public async Task<ActionResult<Student?>> GetByContactDNI(string dni)
    {
        Student? student = await _studentService.GetByContactDNI(dni);
        if (student == null)
            return NotFound();

        return student;
    }

    [HttpGet(nameof(SearchByContactDNI) + "/{dni}")]
    public async Task<ActionResult<List<Student>>> SearchByContactDNI(string dni)
    {
        List<Student> contacts = await _studentService.SearchByContactDNI(dni).ToListAsync();
        if (contacts.Count == 0)
            return NotFound();

        return contacts;
    }
}
