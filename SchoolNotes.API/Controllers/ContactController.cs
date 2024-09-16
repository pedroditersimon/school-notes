using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : GenericController<Contact, Guid>
{

    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
        : base(contactService)
    {
        _contactService = contactService;
    }

    [HttpGet(nameof(SearchByDNI) + "/{dni}")]
    public async Task<ActionResult<List<Contact>>> SearchByDNI(string dni)
    {
        List<Contact> contacts = await _contactService.SearchByDNI(dni).ToListAsync();
        if (contacts.Count <= 0)
            return NotFound();

        return contacts;
    }

    [HttpGet(nameof(GetByDNI) + "/{dni}")]
    public async Task<ActionResult<Contact?>> GetByDNI(string dni)
    {
        Contact? contact = await _contactService.GetByDNI(dni);
        if (contact == null)
            return NotFound();

        return contact;
    }
}
