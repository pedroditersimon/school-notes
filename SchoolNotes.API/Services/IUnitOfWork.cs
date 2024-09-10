using SchoolNotes.API.Repositories;

namespace SchoolNotes.API.Services;

public interface IUnitOfWork : IDisposable
{
    public StudentRepository StudentRepository { get; }

    public Task<bool> Save();
}
