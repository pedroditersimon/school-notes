using Microsoft.EntityFrameworkCore;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.Test.Services;

internal class ContactServiceTest
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public async Task SearchByDNI()
    {
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);

        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID01,
            DNI = "123456789"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID02,
            DNI = "987654321"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID03,
            DNI = "123000321"
        });
        await unitOfWork.Save();

        List<Contact> contacts = await service.SearchByDNI("123456789").ToListAsync();
        Contact? resultContact = contacts.FirstOrDefault();

        Assert.AreEqual(1, contacts.Count);

        Assert.IsNotNull(resultContact);
        Assert.AreEqual(TestsHelper.GUID01, resultContact.ID);
        Assert.AreEqual("123456789", resultContact.DNI);
    }


    [Test]
    public async Task GetByDNI()
    {
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);

        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID01,
            DNI = "123456789"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID02,
            DNI = "987654321"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID03,
            DNI = "123000321"
        });
        await unitOfWork.Save();

        Contact? contact = await service.GetByDNI("123456789");

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("123456789", contact.DNI);
    }
}
