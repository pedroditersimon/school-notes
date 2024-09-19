using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

public class GenericController<T, Tid> : ControllerBase, IGenericController<T, Tid>
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

        return Ok(entity);
    }

    [HttpGet(nameof(GetAll) + "/{limit}")]
    public async Task<ActionResult<List<T>>> GetAll(int limit = 50)
    {
        List<T> entities = await _service.GetAll(limit).ToListAsync();
        return Ok(entities);
    }

    [HttpPost]
    public async Task<ActionResult<T?>> Create(T newEntity)
    {
        T? entity = await _service.Create(newEntity);
        if (entity == null)
            return Conflict();

        return Ok(entity);
    }

    [HttpPut]
    public async Task<ActionResult<T?>> Update(T newEntity)
    {
        T? entity = await _service.Update(newEntity);
        if (entity == null)
            return Conflict();

        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Tid id)
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
