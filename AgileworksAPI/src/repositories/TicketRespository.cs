using AgileworksAPI.Application.Exceptions;
using AgileworksAPI.DatabaseContexts;
using AgileworksAPI.Models.Data;
using AgileworksAPI.Models.Input;

namespace AgileworksAPI.Interfaces.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly MainDatabaseContext _context;

    public TicketRepository(MainDatabaseContext context)
    {
        _context = context;
    }

    public Ticket Create(CreateNewTicketInputModel ticket)
    {
        Ticket newTicket = new Ticket
        {
            CreatedAt = DateTime.UtcNow,
            Description = ticket.Description,
            DeadLineAt = ticket.DeadLineAt
        };
        _context.Tickets.Add(newTicket);
        _context.SaveChanges();
        return newTicket;
    }

    public Ticket Solve(SolveTicketInputModel ticket)
    {
        Ticket? updatedTicket = _context.Tickets.FirstOrDefault(e => e.Id == ticket.TicketId)
            ?? throw new NotFoundException("Ticket was not found");
        updatedTicket.SolvedAt = DateTime.UtcNow;
        _context.SaveChanges();
        return updatedTicket;
    }

    public List<Ticket> GetAll()
    {
        return _context.Tickets.Where(x => x.SolvedAt == null).ToList();
    }
}