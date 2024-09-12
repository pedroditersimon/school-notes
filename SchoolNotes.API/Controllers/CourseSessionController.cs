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
        IQueryable<CourseSession> courseSessions = courseSessionService.GetByStudentID(studentID);
        return await courseSessions.ToListAsync();
    }

    [HttpGet(nameof(GetByCourseID) + "/{courseID}")]
    public async Task<ActionResult<List<CourseSession>>> GetByCourseID(Guid courseID)
    {
        IQueryable<CourseSession> courseSessions = courseSessionService.GetByCourseID(courseID);
        return await courseSessions.ToListAsync();
    }
}
