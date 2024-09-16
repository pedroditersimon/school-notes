using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

public class GenericController<T, Tid> : ControllerBase
    where T : BaseModel<Tid>
    where Tid : IEquatable<Tid>
{

    protected readonly IGenericService<T, Tid> _service;

    public GenericController(IGenericService<T, Tid> service)
    {
        _service = service;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<T?>> Get(Tid id)
    {
        T? entity = await _service.GetByID(id);
        if (entity == null)
            return NotFound();

        return entity;
    }

    [HttpGet(nameof(GetAll) + "/{limit}")]
    public async Task<ActionResult<List<T>>> GetAll(int limit = 50)
    {
        IQueryable<T> entities = _service.GetAll(limit);
        return await entities.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<T?>> Create(T newStudent)
    {
        T? entity = await _service.Create(newStudent);
        if (entity == null)
            return Conflict();

        return entity;
    }

    [HttpPut]
    public async Task<ActionResult<T?>> Update(T newStudent)
    {
        T? entity = await _service.Update(newStudent);
        if (entity == null)
            return Conflict();

        return entity;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<T?>> Delete(Tid id)
    {
        T? entity = await _service.GetByID(id);
        if (entity == null)
            return NotFound();

        bool deleted = await _service.SoftDelete(id);
        if (!deleted)
            return Conflict();

        return Ok();
    }
}
