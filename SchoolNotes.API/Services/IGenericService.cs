namespace SchoolNotes.API.Services;

public interface IGenericService<T, Tid>
{
    public Task<T?> Create(T newEntity);

    public IQueryable<T> GetAll(int limit = 50);

    public Task<bool> Exists(Tid id);

    public Task<T?> GetByID(Tid id);

    public Task<bool> HardDelete(Tid id);

    public Task<bool> SoftDelete(Tid id);

    public Task<T?> Update(T newEntity);
}
