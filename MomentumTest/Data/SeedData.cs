using MomentumTest.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MomentumTest.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<MomentumTestContext>();
            // Check if any reservations already exist
            if (context.Reservation.Any()) return;

            // Retrieve existing statuses from the database
            var statusList = context.Status.ToList();

            // Ensure there are statuses to use
            if (statusList.Count == 0)
            {
                throw new InvalidOperationException("No statuses found in the database to assign to reservations.");
            }

            // Retrieve existing guests from the database
            var guestList = context.Guest.ToList();

            // Ensure there are guests to use
            if (!guestList.Any())
            {
                throw new InvalidOperationException("No guests found in the database to assign to reservations.");
            }

            // Create a list of reservations
            var random = new Random();
            var reservations = new List<Reservation>();

            for (int i = 1; i <= 50; i++)
            {
                var randomStatus = statusList[random.Next(statusList.Count)];
                var startDate = DateTime.Now.AddDays(-random.Next(30)); // Random start date within the last 30 days
                var endDate = startDate.AddDays(random.Next(1, 14)); // Random end date between 1 and 14 days from start date

                var randomGuest = guestList[random.Next(guestList.Count)];

                var reservation = new Reservation
                {
                    Id = i,
                    StartDate = startDate,
                    EndDate = endDate,
                    Observations = $"Reserva {i} com status {randomStatus.Name} gerada automaticamente.",
                    StatusId = randomStatus.Id,
                    Status = randomStatus,
                    MainGuestId = randomGuest.Id, // Use the valid guest's ID
                    MainGuest = randomGuest // Assign the random guest to MainGuest property
                };

                reservations.Add(reservation);
            }

            // Add reservations to the database
            context.Reservation.AddRange(reservations);
            context.SaveChanges();
        }
    }
}
