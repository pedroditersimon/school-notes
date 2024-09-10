﻿namespace SchoolNotes.API.Repositories;

public interface IRepository<T, Tid>
{
    public Task<T?> GetByID(Tid id);

    public Task<T?> Update(T newEntity);
    public Task<T?> Create(T newEntity);

    public Task<bool> SoftDelete(Tid id);
    public Task<bool> HardDelete(Tid id);
}
