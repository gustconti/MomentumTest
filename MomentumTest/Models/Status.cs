using System.ComponentModel.DataAnnotations;

namespace MomentumTest.Models;

public class Status
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public required string Color { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
}