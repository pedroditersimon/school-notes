using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
namespace SchoolNotes.API.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly DBPostgreSQL _dbContext;
    public ContactRepository ContactRepository { get; }
    public StudentRepository StudentRepository { get; }
    public TeacherRepository TeacherRepository { get; }
    public CourseRepository CourseRepository { get; }
    public CourseSessionRepository CourseSessionRepository { get; }
    public CourseSessionStudentRepository CourseSessionStudentRepository { get; }
    public ScoreRepository ScoreRepository { get; }

    public UnitOfWork(DBPostgreSQL dbContext,
                      ContactRepository contactRepository,
                      StudentRepository studentRepository,
                      TeacherRepository teacherRepository,
                      CourseRepository courseRepository,
                      CourseSessionRepository courseSessionRepository,
                      CourseSessionStudentRepository courseSessionStudentRepository,
                      ScoreRepository scoreRepository)
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
