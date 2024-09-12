using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController(CourseService courseService)
    : GenericController<Course, Guid>(courseService)
{


}
