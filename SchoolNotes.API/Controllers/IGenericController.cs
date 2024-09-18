using Microsoft.AspNetCore.Mvc;

namespace SchoolNotes.API.Controllers;

public interface IGenericController<T, Tid>
{

    [HttpGet("{id}")]
    Task<ActionResult<T?>> Get(Tid id);

    [HttpGet(nameof(GetAll) + "/{limit}")]
    Task<ActionResult<List<T>>> GetAll(int limit = 50);

    [HttpPost]
    Task<ActionResult<T?>> Create(T request);

    [HttpPut]
    Task<ActionResult<T?>> Update(T request);

    [HttpDelete("{id}")]
    Task<ActionResult> Delete(Tid id);

}
