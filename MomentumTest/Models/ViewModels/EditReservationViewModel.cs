namespace MomentumTest.Models.ViewModels
{
    public class EditReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public List<Status> Statuses { get; set; }

        public EditReservationViewModel(Reservation reservation, List<Status> statuses)
        {
            Reservation = reservation;
            Statuses = statuses;
        }
    }
}

