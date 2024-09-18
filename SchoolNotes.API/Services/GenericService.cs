using SchoolNotes.API.Repositories.Interfaces;

namespace SchoolNotes.API.Services;

public class GenericService<T, Tid, Trepository> : IGenericService<T, Tid>
    where Trepository : IRepository<T, Tid>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly Trepository _repository;

    public GenericService(IUnitOfWork unitOfWork, Trepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }


    public virtual IQueryable<T> GetAll(int limit = 50) => _repository.GetAll(limit);

    public virtual Task<T?> GetByID(Tid id) => _repository.GetByID(id);

    public virtual Task<bool> Exists(Tid id) => _repository.Exists(id);


    public virtual async Task<T?> Create(T newEntity)
    {
        T? entity = await _repository.Create(newEntity);
        if (entity == null)
            return default;

        bool saved = await _unitOfWork.Save();
        if (!saved)
            return default;

        return entity;
    }


    public virtual async Task<T?> Update(T newEntity)
    {
        T? entity = await _repository.Update(newEntity);
        if (entity == null)
            return default;

        bool saved = await _unitOfWork.Save();
        if (!saved)
            return default;

        return entity;
    }

    public virtual async Task<bool> HardDelete(Tid id)
    {

        bool deleted = await _repository.HardDelete(id);
        if (!deleted)
            return false;

        bool saved = await _unitOfWork.Save();
        if (!saved)
            return false;

        return true;
    }

    public virtual async Task<bool> SoftDelete(Tid id)
    {
        bool deleted = await _repository.SoftDelete(id);
        if (!deleted)
            return false;

        bool saved = await _unitOfWork.Save();
        if (!saved)
            return false;

        return true;
    }


}
