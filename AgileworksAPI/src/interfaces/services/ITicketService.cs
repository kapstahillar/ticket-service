using AgileworksAPI.DTO;
using AgileworksAPI.Models.Input;

namespace AgileworksAPI.Interfaces.Services;

public interface ITicketService
{
    TicketDTO Create(CreateNewTicketInputModel ticket);
    TicketDTO Solve(SolveTicketInputModel ticket);
    List<TicketDTO> GetAll();
}