namespace AgileworksAPI.DTO;

public record class TicketDTO(
    long Id,
    string? Description,
    DateTime CreatedAt,
    DateTime DeadLineAt,
    DateTime? SolvedAt
);