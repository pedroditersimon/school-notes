using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : GenericController<Teacher, Guid>
{
    private readonly TeacherService _teacherService;

    public TeacherController(TeacherService teacherService)
        : base(teacherService)
    {
        _teacherService = teacherService;
    }


    [HttpGet(nameof(GetByContactDNI) + "/{dni}")]
    public async Task<ActionResult<Teacher?>> GetByContactDNI(string dni)
    {
        Teacher? teacher = await _teacherService.GetByContactDNI(dni);
        if (teacher == null)
            return NotFound();

        return teacher;
    }

    [HttpGet(nameof(SearchByContactDNI) + "/{dni}")]
    public async Task<ActionResult<List<Teacher>>> SearchByContactDNI(string dni)
    {
        List<Teacher> teachers = await _teacherService.SearchByContactDNI(dni).ToListAsync();
        if (teachers.Count == 0)
            return NotFound();

        return teachers;
    }
}
