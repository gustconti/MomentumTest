using System.ComponentModel.DataAnnotations;

namespace MomentumTest.Models.ViewModels
{
    public class EditReservationViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string? Observations { get; set; }

        public int? StatusId { get; set; }

        public Guest? MainGuest { get; set; }

        public List<string>? AdditionalGuests { get; set; }

        public EditReservationViewModel() { }

        public static EditReservationViewModel FromReservation(Reservation reservation)
        {
            return new EditReservationViewModel
            {
                Id = reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                Observations = reservation.Observations,
                StatusId = reservation.StatusId,
                MainGuest = reservation.MainGuest,
                AdditionalGuests = reservation.AdditionalGuests
            };
        }
    }
}
