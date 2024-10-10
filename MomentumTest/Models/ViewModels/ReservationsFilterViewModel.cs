using System.ComponentModel.DataAnnotations;
namespace MomentumTest.Models.ViewModels
{
    public class ReservationsFilterViewModel
    {
        [Display(Name = "Número")]
        public int? ReservationId { get; set; }
        [Display(Name = "Data de Início")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Data de Término")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [Display(Name = "Nome do Hóspede")]
        public string? GuestName { get; set; }
        public List<Status> Statuses { get; set; } = [];
        public ReservationsFilterViewModel() { }
        public ReservationsFilterViewModel(Reservation reservation)
        {
            ReservationId = reservation.Id;
            StartDate = reservation.StartDate;
            EndDate = reservation.EndDate;
            StatusId = reservation.StatusId;
            GuestName = reservation.MainGuest?.Name;
        }
    }
}