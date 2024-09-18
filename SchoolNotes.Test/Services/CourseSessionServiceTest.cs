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
}
