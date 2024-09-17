using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Repositories;

public class Repository<T, Tid> : IRepository<T, Tid>
    where T : BaseModel<Tid>
    where Tid : IEquatable<Tid>
{

    protected readonly DbContext _dbContext;
    protected DbSet<T> Entities => _dbContext.Set<T>();

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public virtual async Task<T?> GetByID(Tid id)
        => await Entities.SingleOrDefaultAsync(e => e.ID.Equals(id));
    public virtual IQueryable<T> GetAll(int limit = 50)
        => Entities.Take(limit);


    public virtual async Task<bool> Exists(Tid id)
        => await GetByID(id) != null;

    public virtual async Task<T?> Create(T newEntity)
        => Entities.Add(newEntity).Entity;

    public virtual async Task<bool> HardDelete(Tid id)
    {
        T? entity = await GetByID(id);
        if (entity == null)
            return false;

        Entities.Remove(entity);
        return true;
    }


    public virtual async Task<bool> SoftDelete(Tid id)
    {
        T? entity = await GetByID(id);
        if (entity == null)
            return false;

        entity.IsDeleted = true;
        return true;
    }


    public virtual async Task<T?> Update(T newEntity)
    {
        T? existingEntity = await GetByID(newEntity.ID);
        if (existingEntity == null)
            return null;

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(newEntity);
        return existingEntity;
    }


}
