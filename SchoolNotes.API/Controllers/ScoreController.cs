using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController(ScoreService scoreService)
    : GenericController<Score, Guid>(scoreService)
{
    [HttpGet(nameof(GetByStudentID) + "{studentID}")]
    public async Task<ActionResult<List<Score>>> GetByStudentID(Guid studentID)
    {
        IQueryable<Score> scores = scoreService.GetByStudentID(studentID);
        return await scores.ToListAsync();
    }


    [HttpGet(nameof(GetByCourseSessionID) + "{courseSessionID}")]
    public async Task<ActionResult<List<Score>>> GetByCourseSessionID(Guid courseSessionID)
    {
        IQueryable<Score> scores = scoreService.GetByCourseSessionID(courseSessionID);
        return await scores.ToListAsync();
    }
}
