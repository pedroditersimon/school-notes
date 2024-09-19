using Microsoft.AspNetCore.Mvc;
using SchoolNotes.API.Controllers;
using SchoolNotes.API.DTOs.Contact;
using SchoolNotes.API.Models;
using SchoolNotes.API.Services;

namespace SchoolNotes.Test.Controllers;

internal class ContactControllerTest
{

    [SetUp]
    public void SetUp()
    {

    }

    static async Task InsertTestContacts(IUnitOfWork unitOfWork, ContactService service)
    {
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID01,
            FirstName = "Juan",
            LastName = "Perez",
            DNI = "123456789"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID02,
            FirstName = "Maria",
            LastName = "Garcia",
            DNI = "987654321"
        });
        await service.Create(new Contact()
        {
            ID = TestsHelper.GUID03,
            FirstName = "Carlos",
            LastName = "Lopez",
            DNI = "123000321"
        });

        await unitOfWork.Save();
    }

    [Test]
    public async Task SearchByDNI_200ForValidDNI()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        ActionResult<List<Contact>> response = await controller.SearchByDNI("123456789");
        List<Contact>? contacts = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contacts);
        Assert.IsNotEmpty(contacts);
        Assert.AreEqual(1, contacts.Count);

        Contact? resultContact = contacts.FirstOrDefault();
        Assert.IsNotNull(resultContact);
        Assert.AreEqual(TestsHelper.GUID01, resultContact.ID);
        Assert.AreEqual("123456789", resultContact.DNI);
    }

    [Test]
    public async Task SearchByDNI_404ForInvalidDNI()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        ActionResult<List<Contact>> response = await controller.SearchByDNI("01329850");
        List<Contact>? contacts = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contacts);
        Assert.IsEmpty(contacts);
    }

    [Test]
    public async Task GetByDNI_200ForValidDNI()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);


        // Act
        ActionResult<Contact?> response = await controller.GetByDNI("123456789");
        Contact? contact = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("123456789", contact.DNI);
    }

    [Test]
    public async Task GetByDNI_404ForInvalidDNI()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.GetByDNI("01329850");

        // Assert
        Assert.IsTrue(response.Result is NotFoundResult, "Expected 404 status code");
    }

    [Test]
    public async Task Get_200ForValidID()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);


        // Act
        ActionResult<ContactResult?> response = await controller.Get(TestsHelper.GUID01);
        ContactResult? contact = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contact);
        Assert.AreEqual(TestsHelper.GUID01, contact.ID);
        Assert.AreEqual("123456789", contact.DNI);
    }

    [Test]
    public async Task Get_404ForInvalidID()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.Get(Guid.NewGuid());

        // Assert
        Assert.IsTrue(response.Result is NotFoundResult, "Expected 404 status code");
    }


    [Test]
    public async Task Create_200ForValidObject()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        // Act
        var response = await controller.Create(new()
        {
            FirstName = "test name",
            LastName = "test last name",
            DNI = "012345678"
        });
        ContactResult? contact = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contact);
        Assert.AreEqual("test name", contact.FirstName);
        Assert.AreEqual("test last name", contact.LastName);
        Assert.AreEqual("012345678", contact.DNI);
    }


    [Test]
    public async Task Update_200ForValidObject()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.Update(new()
        {
            ID = TestsHelper.GUID02,
            FirstName = "test name",
            LastName = "test last name",
            DNI = "012345678"
        });
        ContactResult? contact = response.ReturnValue();

        // Assert
        Assert.IsTrue(response.Result is OkObjectResult, "Expected 200 status code");

        Assert.IsNotNull(contact);
        Assert.AreEqual("test name", contact.FirstName);
        Assert.AreEqual("test last name", contact.LastName);
        Assert.AreEqual("012345678", contact.DNI);
    }

    [Test]
    public async Task Update_404ForInvalidID()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.Update(new()
        {
            ID = Guid.NewGuid(),
            FirstName = "test name",
            LastName = "test last name",
            DNI = "012345678"
        });

        // Assert
        Assert.IsTrue(response.Result is NotFoundResult, "Expected 404 status code");
    }

    [Test]
    public async Task Delete_200ForValidID()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.Delete(TestsHelper.GUID01);

        // Assert
        Assert.IsTrue(response is OkResult, "Expected 200 status code");
    }

    [Test]
    public async Task Delete_404ForInvalidID()
    {
        // Arrenge
        IUnitOfWork unitOfWork = TestsHelper.CreateInMemoryUnitOfWork();
        ContactService service = new(unitOfWork);
        ContactController controller = new(service);

        await InsertTestContacts(unitOfWork, service);

        // Act
        var response = await controller.Delete(Guid.NewGuid());

        // Assert
        Assert.IsTrue(response is NotFoundResult, "Expected 404 status code");
    }


}
