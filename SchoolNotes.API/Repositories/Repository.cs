using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class Repository<T, Tid>(DbContext dbContext) : IRepository<T, Tid>
    where T : BaseModel<Tid>
    where Tid : IEquatable<Tid>
{

    protected DbSet<T> Entities => dbContext.Set<T>();


    public async Task<T?> GetByID(Tid id)
        => await Entities.Where(e => e.ID.Equals(id)).FirstOrDefaultAsync();
    public IQueryable<T> GetAll(int limit = 50)
        => Entities.Take(limit);

    public async Task<T?> Create(T newEntity)
        => Entities.Add(newEntity).Entity;

    public async Task<bool> HardDelete(Tid id)
    {
        T? entity = await GetByID(id);
        if (entity == null)
            return false;

        Entities.Remove(entity);
        return true;
    }


    public async Task<bool> SoftDelete(Tid id)
    {
        T? entity = await GetByID(id);
        if (entity == null)
            return false;

        entity.IsDeleted = true;
        return true;
    }


    public async Task<T?> Update(T newEntity)
    {
        T? existingEntity = await GetByID(newEntity.ID);
        if (existingEntity == null)
            return null;

        dbContext.Entry(existingEntity).CurrentValues.SetValues(newEntity);
        return existingEntity;
    }
}
