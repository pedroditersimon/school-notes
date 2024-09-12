using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
namespace SchoolNotes.API.Services;

public class UnitOfWork(DBPostgreSQL dbContext,
    StudentRepository studentRepository, CourseRepository courseRepository,
    CourseSessionRepository courseSessionRepository,
    CourseSessionStudentRepository courseSessionStudentRepository,
    ScoreRepository scoreRepository) : IUnitOfWork
{
    public StudentRepository StudentRepository { get; } = studentRepository;
    public CourseRepository CourseRepository { get; } = courseRepository;
    public CourseSessionRepository CourseSessionRepository { get; } = courseSessionRepository;
    public CourseSessionStudentRepository CourseSessionStudentRepository { get; } = courseSessionStudentRepository;
    public ScoreRepository ScoreRepository { get; } = scoreRepository;



    public void Dispose()
        => dbContext.Dispose();

    public async Task<bool> Save()
        => await dbContext.SaveChangesAsync() > 0;

}
