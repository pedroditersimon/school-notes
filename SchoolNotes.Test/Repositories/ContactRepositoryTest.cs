using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Database;
using SchoolNotes.API.Models;
using SchoolNotes.API.Repositories;

namespace SchoolNotes.Test.Repositories;

internal class ContactRepositoryTest
{


    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public async Task CreateContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        Contact? contact = await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("123456789", contact.DNI);
    }

    [Test]
    public async Task GetContactThatExists()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("123456789", contact.DNI);
    }

    [Test]
    public async Task GetContactThatDoesNotExists()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsNull(contact);
    }

    [Test]
    public async Task GetAllWithExactAmount()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        for (int i = 0; i < 5; i++)
        {
            await repository.Create(new()
            {
                ID = Guid.NewGuid(),
                FirstName = "TestName"
            });
        }
        await dbContext.SaveChangesAsync();

        List<Contact> contacts = await repository.GetAll().ToListAsync();

        Assert.AreEqual(5, contacts.Count);

        Assert.IsTrue(contacts.All(c => c != null));
        Assert.IsTrue(contacts.All(c => c.ID != Guid.Empty));
        Assert.IsTrue(contacts.All(c => c.FirstName.Equals("TestName")));
    }



    [Test]
    public async Task UpdateContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();

        insertedContact.DNI = "987654321";
        insertedContact.FirstName = "TestName";

        await repository.Update(insertedContact);
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("987654321", contact.DNI);
        Assert.AreEqual("TestName", contact.FirstName);
    }

    [Test]
    public async Task SoftDeleteContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();

        bool deleted = await repository.SoftDelete(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsTrue(deleted);
        Assert.IsNotNull(contact);
        Assert.IsTrue(contact.IsDeleted);
    }

    [Test]
    public async Task HardDeleteContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();

        bool deleted = await repository.HardDelete(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsTrue(deleted);
        Assert.IsNull(contact);
    }

    [Test]
    public async Task SoftDeleteContactThatDoesNotExists()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        bool deleted = await repository.SoftDelete(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsFalse(deleted);
        Assert.IsNull(contact);
    }

    [Test]
    public async Task HardDeleteContactThatDoesNotExists()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        bool deleted = await repository.HardDelete(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        await dbContext.SaveChangesAsync();

        Contact? contact = await repository.GetByID(Guid.Parse("00000000-0000-0000-0000-000000000001"));

        Assert.IsFalse(deleted);
        Assert.IsNull(contact);
    }


    [Test]
    public async Task ExistsCreatedContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        Contact insertedContact = new()
        {
            ID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            DNI = "123456789"
        };
        Contact? contact = await repository.Create(insertedContact);
        await dbContext.SaveChangesAsync();


        bool exists = await repository.Exists(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        Assert.IsTrue(exists);
    }

    [Test]
    public async Task NotExistsContact()
    {
        SchoolNotesDbContext dbContext = TestsHelper.CreateInMemoryDBContext();
        ContactRepository repository = new(dbContext);

        bool exists = await repository.Exists(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        Assert.IsFalse(exists);
    }
}
