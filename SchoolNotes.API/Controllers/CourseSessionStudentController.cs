using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseSessionStudentController(CourseSessionStudentService courseSessionStudentService)
    : GenericController<CourseSessionStudent, Guid>(courseSessionStudentService)
{

    [HttpGet(nameof(GetByStudentID) + "/{studentID}")]
    public async Task<ActionResult<List<CourseSessionStudent>>> GetByStudentID(Guid studentID)
    {
        return await courseSessionStudentService.GetByStudentID(studentID);
    }


    [HttpGet(nameof(GetByCourseSessionID) + "/{courseSessionID}")]
    public async Task<ActionResult<List<CourseSessionStudent>>> GetByCourseSessionID(Guid courseSessionID)
    {
        return await courseSessionStudentService.GetByCourseSessionID(courseSessionID);
    }

}
