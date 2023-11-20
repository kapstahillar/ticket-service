using AgileworksAPI.Models.Data;
using AgileworksAPI.Models.Input;

namespace AgileworksAPI.Interfaces.Repositories;

public interface ITicketRepository
{
    Ticket Create(CreateNewTicketInputModel ticket);
    Ticket Solve(SolveTicketInputModel ticket);
    List<Ticket> GetAll();
}