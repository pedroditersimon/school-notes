using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : GenericController<Teacher, Guid>
{
    public TeacherController(TeacherService teacherService)
        : base(teacherService)
    {
    }
}
