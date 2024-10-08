using System.ComponentModel.DataAnnotations;

namespace MomentumTest.Models;

public class Reservation
{
    public int Id { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public int StatusId { get; set; }
}