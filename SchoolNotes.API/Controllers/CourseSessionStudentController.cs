using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseSessionStudentController(CourseSessionStudentService courseSessionStudentService)
    : GenericController<CourseSessionStudent, Guid>(courseSessionStudentService)
{



    [HttpGet(nameof(GetByStudentID) + "/{id}")]
    public async Task<ActionResult<List<CourseSessionStudent>>> GetByStudentID(Guid id)
    {
        return await courseSessionStudentService.GetByStudentID(id);
    }


    [HttpGet(nameof(GetByCourseSessionID) + "/{id}")]
    public async Task<ActionResult<List<CourseSessionStudent>>> GetByCourseSessionID(Guid id)
    {
        return await courseSessionStudentService.GetByCourseSessionID(id);
    }



}

