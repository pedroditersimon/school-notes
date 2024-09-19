using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.DTOs.Contact;
using SchoolNotes.API.Mappers;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{

    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet(nameof(SearchByDNI) + "/{dni}")]
    public async Task<ActionResult<List<Contact>>> SearchByDNI(string dni)
    {
        List<Contact> contacts = await _contactService.SearchByDNI(dni).ToListAsync();
        return Ok(contacts);
    }

    [HttpGet(nameof(GetByDNI) + "/{dni}")]
    public async Task<ActionResult<Contact?>> GetByDNI(string dni)
    {
        Contact? contact = await _contactService.GetByDNI(dni);
        if (contact == null)
            return NotFound();

        return Ok(contact);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactResult?>> Get(Guid id)
    {
        Contact? contact = await _contactService.GetByID(id);
        if (contact == null)
            return NotFound();

        return Ok(contact.ToResult());
    }

    [HttpGet(nameof(GetAll) + "/{limit}")]
    public async Task<ActionResult<List<ContactResult>>> GetAll(int limit = 50)
    {
        List<Contact> contacts = await _contactService.GetAll(limit).ToListAsync();
        var contactResults = contacts.Select(c => c.ToResult()).ToList();
        return Ok(contactResults);
    }

    [HttpPost]
    public async Task<ActionResult<ContactResult?>> Create(CreateContactRequest request)
    {
        Contact? contact = await _contactService.Create(request.ToContact());

        if (contact == null)
            return Conflict();

        return Ok(contact.ToResult());
    }

    [HttpPut]
    public async Task<ActionResult<ContactResult?>> Update(UpdateContactRequest request)
    {
        bool exists = await _contactService.Exists(request.ID);
        if (!exists)
            return NotFound();

        Contact? contact = await _contactService.Update(request.ToContact());
        if (contact == null)
            return Conflict();

        return Ok(contact.ToResult());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        bool exists = await _contactService.Exists(id);
        if (!exists)
            return NotFound();

        bool deleted = await _contactService.SoftDelete(id);
        if (!deleted)
            return Conflict();

        return Ok();
    }
}
