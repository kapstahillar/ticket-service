using AgileworksAPI.DTO;
using AgileworksAPI.Interfaces.Repositories;
using AgileworksAPI.Models.Input;

namespace AgileworksAPI.Interfaces.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    public TicketDTO Create(CreateNewTicketInputModel ticket)
    {
        return _repository.Create(ticket).toDTO();
    }

    public TicketDTO Solve(SolveTicketInputModel ticket)
    {
        return _repository.Solve(ticket).toDTO();
    }

    public List<TicketDTO> GetAll()
    {
        return _repository.GetAll().ConvertAll<TicketDTO>(obj => obj.toDTO());
    }
}