#pragma warning disable 1998

using AgileworksAPI.Interfaces.Services;
using AgileworksAPI.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace AgileworksAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_ticketService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewTicketInputModel ticket)
    {
        return Ok(_ticketService.Create(ticket));
    }

    [HttpPut]
    public async Task<IActionResult> Solve([FromBody] SolveTicketInputModel ticket)
    {
        return Ok(_ticketService.Solve(ticket));
    }
}