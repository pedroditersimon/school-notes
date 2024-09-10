using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public class UnitOfWork(DbContext dbContext, StudentRepository studentRepository) : IUnitOfWork
{
    public StudentRepository StudentRepository { get; set; } = studentRepository;

    public void Dispose()
        => dbContext.Dispose();

    public async Task<bool> Save()
        => await dbContext.SaveChangesAsync() > 0;

}
