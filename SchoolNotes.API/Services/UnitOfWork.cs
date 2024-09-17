using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories.Interfaces;
namespace SchoolNotes.API.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly DBPostgreSQL _dbContext;
    public IContactRepository ContactRepository { get; }
    public IStudentRepository StudentRepository { get; }
    public ITeacherRepository TeacherRepository { get; }
    public ICourseRepository CourseRepository { get; }
    public ICourseSessionRepository CourseSessionRepository { get; }
    public ICourseSessionStudentRepository CourseSessionStudentRepository { get; }
    public IScoreRepository ScoreRepository { get; }

    public UnitOfWork(DBPostgreSQL dbContext,
                      IContactRepository contactRepository,
                      IStudentRepository studentRepository,
                      ITeacherRepository teacherRepository,
                      ICourseRepository courseRepository,
                      ICourseSessionRepository courseSessionRepository,
                      ICourseSessionStudentRepository courseSessionStudentRepository,
                      IScoreRepository scoreRepository)
    {
        _dbContext = dbContext;
        ContactRepository = contactRepository;
        StudentRepository = studentRepository;
        TeacherRepository = teacherRepository;
        CourseRepository = courseRepository;
        CourseSessionRepository = courseSessionRepository;
        CourseSessionStudentRepository = courseSessionStudentRepository;
        ScoreRepository = scoreRepository;
    }

    public void Dispose()
        => _dbContext.Dispose();

    public async Task<bool> Save()
        => await _dbContext.SaveChangesAsync() > 0;

}
