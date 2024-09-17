namespace SchoolNotes.API.Repositories.Interfaces;

public interface IRepository<T, Tid>
{
    public Task<T?> GetByID(Tid id);
    public IQueryable<T> GetAll(int limit = 50);

    public Task<bool> Exists(Tid id);

    public Task<T?> Update(T newEntity);
    public Task<T?> Create(T newEntity);

    public Task<bool> SoftDelete(Tid id);
    public Task<bool> HardDelete(Tid id);
}
