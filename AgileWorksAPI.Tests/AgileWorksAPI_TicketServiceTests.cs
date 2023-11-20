using System.Globalization;
using AgileworksAPI.Interfaces.Repositories;
using AgileworksAPI.Interfaces.Services;
using AgileworksAPI.Models.Data;
using AgileworksAPI.Models.Input;
using Moq;

namespace AgileWorksAPI.Tests;

public class TicketServiceTests
{
    [Fact]
    public void Will_GetAll_ReturnAListOfTicketsContainingOneTicket()
    {
        // Arrange
        var instance = GetTestCreateInputModelInstance();
        var mockRepo = new Mock<ITicketRepository>();
        mockRepo.Setup(repo => repo.Create(instance))
            .Returns(GetTestTicket());
        mockRepo.Setup(repo => repo.GetAll())
            .Returns(GetTestTickets());
        var service = new TicketService(mockRepo.Object);

        // Act
        var ticket = service.Create(instance);
        var result = service.GetAll();

        // Assert
        Assert.True(result.Count > 0);
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

    private Ticket GetTestTicket()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl = DateTime.ParseExact("2023-11-19T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);
        return new Ticket
        {
            Id = 1,
            Description = "Test one",
            CreatedAt = DateTime.UtcNow,
            SolvedAt = null,
            DeadLineAt = dl
        };
    }

    private List<Ticket> GetTestTickets()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime dl1 = DateTime.ParseExact("2023-11-20T19:00:00", "yyyy-MM-ddTHH:mm:ss", provider);
        DateTime dl2 = DateTime.ParseExact("2023-11-20T19:15:00", "yyyy-MM-ddTHH:mm:ss", provider);
        var tickets = new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                Description = "Test one",
                CreatedAt = DateTime.UtcNow,
                SolvedAt = null,
                DeadLineAt = dl1
            },
            new Ticket
            {
                Id = 2,
                Description = "Test two",
                CreatedAt = DateTime.UtcNow,
                SolvedAt = null,
                DeadLineAt = dl2
            }
        };
        return tickets;
    }
}