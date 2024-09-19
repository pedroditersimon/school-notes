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
    [HttpGet(nameof(GetByStudentID) + "/{studentID}")]
    public async Task<ActionResult<List<Score>>> GetByStudentID(Guid studentID)
    {
        List<Score> scores = await scoreService.GetByStudentID(studentID).ToListAsync();
        return Ok(scores);
    }


    [HttpGet(nameof(GetByCourseSessionID) + "/{courseSessionID}")]
    public async Task<ActionResult<List<Score>>> GetByCourseSessionID(Guid courseSessionID)
    {
        List<Score> scores = await scoreService.GetByCourseSessionID(courseSessionID).ToListAsync();
        return Ok(scores);
    }
}
