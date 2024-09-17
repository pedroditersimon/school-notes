using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public interface IUnitOfWork : IDisposable
{
    public IContactRepository ContactRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public ITeacherRepository TeacherRepository { get; }
    public ICourseRepository CourseRepository { get; }
    public ICourseSessionRepository CourseSessionRepository { get; }
    public ICourseSessionStudentRepository CourseSessionStudentRepository { get; }
    public IScoreRepository ScoreRepository { get; }

    public Task<bool> Save();
}
