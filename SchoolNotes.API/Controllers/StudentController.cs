using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(StudentService studentService)
    : GenericController<Student, Guid>(studentService)
{

    [HttpGet(nameof(GetByCourseSessionID) + "/{courseSessionID}")]
    public async Task<ActionResult<List<Student>>> GetByCourseSessionID(Guid courseSessionID)
    {
        IQueryable<Student> students = studentService.GetByCourseSessionID(courseSessionID);
        return await students.ToListAsync();
    }

}
