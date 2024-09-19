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
        List<CourseSessionStudent> courseSessionStudents = await courseSessionStudentService.GetByStudentID(studentID);
        return Ok(courseSessionStudents);
    }


    [HttpGet(nameof(GetByCourseSessionID) + "/{courseSessionID}")]
    public async Task<ActionResult<List<CourseSessionStudent>>> GetByCourseSessionID(Guid courseSessionID)
    {
        List<CourseSessionStudent> courseSessionStudents = await courseSessionStudentService.GetByCourseSessionID(courseSessionID);
        return Ok(courseSessionStudents);
    }

}
