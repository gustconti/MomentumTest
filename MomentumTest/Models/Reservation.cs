using System.ComponentModel.DataAnnotations;

namespace MomentumTest.Models;

public class Reservation
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public string? Observations { get; set; }
    public required int StatusId { get; set; }
    public Status? Status { get; set; }
    public required int MainGuestId { get; set; }
    public Guest? MainGuest { get; set; }
    public List<string>? AdditionalGuests { get; set; } = [];
}