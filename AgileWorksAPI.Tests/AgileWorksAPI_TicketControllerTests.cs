using System.Globalization;
using AgileworksAPI.Controllers;
using AgileworksAPI.DTO;
using AgileworksAPI.Interfaces.Services;
using AgileworksAPI.Models.Input;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AgileWorksAPI.Tests;

public class TicketControllerTests
{
    [Fact]
    public async Task Will_GetAll_ReturnSuccessStatus()
    {
        // Arrange
        var mockService = new Mock<ITicketService>();
        mockService.Setup(service => service.GetAll())
            .Returns(GetTestTickets());
        var controller = new TicketController(mockService.Object);

        // Act
        var result = await controller.GetAll();

        // Assert
        StatusCodeResult? statusCodeResult = result as StatusCodeResult;
        if (statusCodeResult != null)
        {
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
    }

    [Fact]
    public async Task Will_Create_ReturnSuccessStatus()
    {
        // Arrange
        var mockService = new Mock<ITicketService>();
        mockService.Setup(ticketService => ticketService.GetAll())
            .Returns(GetTestTickets());
        var controller = new TicketController(mockService.Object);
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl = DateTime.ParseExact("2023-11-19T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);

        // Act
        var result = await controller.Create(new CreateNewTicketInputModel()
        {
            Description = "Test One",
            DeadLineAt = dl
        });

        // Assert
        StatusCodeResult? statusCodeResult = result as StatusCodeResult;
        if (statusCodeResult != null)
        {
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
    }

    [Fact]
    public async Task Will_Create_ANewTicketWithDescriptionTestOne()
    {
        // Arrange
        var mockService = new Mock<ITicketService>();
        var testInstance = GetTestCreateInputModelInstance();
        mockService.Setup(service => service.Create(testInstance)).Returns(GetTestTicket());
        var controller = new TicketController(mockService.Object);

        // Act
        var result = await controller.Create(testInstance);
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = okResult.Value as TicketDTO;

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Test One", response.Description);
    }

    private List<TicketDTO> GetTestTickets()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl1 = DateTime.ParseExact("2023-11-20T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);
        DateTime dl2 = DateTime.ParseExact("2023-11-20T19:15:00", "yyyy-MM-ddTHH:mm:ss", provider);

        var tickets = new List<TicketDTO>
        {
            new TicketDTO(1, "Test One", DateTime.UtcNow, dl1, null),
            new TicketDTO(2, "Test Two", DateTime.UtcNow, dl2, null)
        };
        return tickets;
    }

    private CreateNewTicketInputModel GetTestCreateInputModelInstance()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl = DateTime.ParseExact("2023-11-20T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);
        return new CreateNewTicketInputModel()
        {
            Description = "Test One",
            DeadLineAt = dl
        };
    }

    private TicketDTO GetTestTicket()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl = DateTime.ParseExact("2023-11-19T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);
        return new TicketDTO(1, "Test One", DateTime.UtcNow, dl, null);
    }
}