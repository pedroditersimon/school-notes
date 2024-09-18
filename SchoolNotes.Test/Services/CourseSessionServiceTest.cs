using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.Test.Services;

internal class CourseSessionServiceTest
{
    [SetUp]
    public void SetUp() { }

    [Test]
    public async Task AssignTeacher()
    {
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        CourseSessionService service = new(unitOfWork);

        await unitOfWork.TeacherRepository.Create(new Teacher()
        {
            ID = TestsHelper.GUID01
        });

        await unitOfWork.CourseSessionRepository.Create(new CourseSession()
        {
            ID = TestsHelper.GUID02,
            CourseID = Guid.Empty
        });
        await unitOfWork.Save();

        CourseSession? courseSession = await service.AssignTeacher(TestsHelper.GUID02, TestsHelper.GUID01);
        await unitOfWork.Save();

        Assert.IsNotNull(courseSession);
        Assert.AreEqual(TestsHelper.GUID01, courseSession.TeacherID);
    }


    [Test]
    public async Task GetByStudentID()
    {
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        CourseSessionService service = new(unitOfWork);

        await unitOfWork.StudentRepository.Create(new Student()
        {
            ID = TestsHelper.GUID01
        });

        await unitOfWork.CourseRepository.Create(new Course()
        {
            ID = TestsHelper.GUID02,
        });

        await unitOfWork.CourseSessionRepository.Create(new CourseSession()
        {
            ID = TestsHelper.GUID03,
            CourseID = TestsHelper.GUID02
        });

        await unitOfWork.CourseSessionStudentRepository.Create(new CourseSessionStudent()
        {
            ID = TestsHelper.GUID04,
            CourseSessionID = TestsHelper.GUID03,
            StudentID = TestsHelper.GUID01
        });
        await unitOfWork.Save();

        List<CourseSession> courseSessions = await service.GetByStudentID(TestsHelper.GUID01).ToListAsync();

        Assert.IsNotNull(courseSessions);
        Assert.Greater(courseSessions.Count, 0);
        Assert.AreEqual(1, courseSessions.Count);
    }

    [Test]
    public async Task GetByCourseID()
    {
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        CourseSessionService service = new(unitOfWork);

        await unitOfWork.CourseRepository.Create(new Course()
        {
            ID = TestsHelper.GUID01,
        });

        await unitOfWork.CourseSessionRepository.Create(new CourseSession()
        {
            ID = TestsHelper.GUID02,
            CourseID = TestsHelper.GUID01
        });

        await unitOfWork.Save();

        List<CourseSession> courseSessions = await service.GetByCourseID(TestsHelper.GUID01).ToListAsync();

        Assert.IsNotNull(courseSessions);
        Assert.Greater(courseSessions.Count, 0);
        Assert.AreEqual(1, courseSessions.Count);
    }
}
