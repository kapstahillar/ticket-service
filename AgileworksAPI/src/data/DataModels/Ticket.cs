using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgileworksAPI.DTO;

namespace AgileworksAPI.Models.Data;

public class Ticket
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string? Description { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime DeadLineAt { get; set; }
    public DateTime? SolvedAt { get; set; }

    public TicketDTO toDTO()
    {
        return new TicketDTO(
            Id,
            Description,
            CreatedAt,
            DeadLineAt,
            SolvedAt
        );
    }
}