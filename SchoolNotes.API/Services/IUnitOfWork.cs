using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public interface IUnitOfWork : IDisposable
{
    public ContactRepository ContactRepository { get; }
    public StudentRepository StudentRepository { get; }
    public TeacherRepository TeacherRepository { get; }
    public CourseRepository CourseRepository { get; }
    public CourseSessionRepository CourseSessionRepository { get; }
    public CourseSessionStudentRepository CourseSessionStudentRepository { get; }
    public ScoreRepository ScoreRepository { get; }

    public Task<bool> Save();
}
