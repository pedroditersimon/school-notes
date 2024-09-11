using SchoolNotes.API.Database;
using SchoolNotes.API.Repositories;
namespace SchoolNotes.API.Services;

public class UnitOfWork(DBPostgreSQL dbContext, StudentRepository studentRepository) : IUnitOfWork
{
    public StudentRepository StudentRepository { get; } = studentRepository;

    public void Dispose()
        => dbContext.Dispose();

    public async Task<bool> Save()
        => await dbContext.SaveChangesAsync() > 0;

}
