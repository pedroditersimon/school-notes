using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseSessionController(CourseSessionService courseSessionService)
    : GenericController<CourseSession, Guid>(courseSessionService)
{

    [HttpGet(nameof(GetByStudentID) + "/{studentID}")]
    public async Task<ActionResult<List<CourseSession>>> GetByStudentID(Guid studentID)
    {
        List<CourseSession> courseSessions = await courseSessionService.GetByStudentID(studentID).ToListAsync();
        return Ok(courseSessions);
    }

    [HttpGet(nameof(GetByCourseID) + "/{courseID}")]
    public async Task<ActionResult<List<CourseSession>>> GetByCourseID(Guid courseID)
    {
        List<CourseSession> courseSessions = await courseSessionService.GetByCourseID(courseID).ToListAsync();
        return Ok(courseSessions);
    }


    [HttpPost(nameof(AssignTeacher))]
    public async Task<ActionResult<CourseSession?>> AssignTeacher(Guid courseID, Guid teacherID)
    {
        CourseSession? courseSession = await courseSessionService.AssignTeacher(courseID, teacherID);
        if (courseSession == null)
            return NotFound();

        return Ok(courseSession);
    }
}
