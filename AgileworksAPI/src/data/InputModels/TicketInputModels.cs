using System.ComponentModel.DataAnnotations;

namespace AgileworksAPI.Models.Input;

public class CreateNewTicketInputModel
{
    [Required]
    [MaxLength(250)]
    public string? Description { get; set; }

    [Required]
    public DateTime DeadLineAt { get; set; }
}

public class SolveTicketInputModel
{
    [Required]
    public long TicketId { get; set; }
}