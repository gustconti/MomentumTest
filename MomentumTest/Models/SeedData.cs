// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using MomentumTest.Data;
// using System;
// using System.Linq;

// namespace MomentumTest.Models;

// public static class SeedData
// {
//     public static void Initialize(IServiceProvider serviceProvider)
//     {
//         using (var context = new MomentumTestContext(
//             serviceProvider.GetRequiredService<
//                 DbContextOptions<MomentumTestContext>>()))
//         {
//             // Look for any Reservations.
//             if (context.Reservation.Any())
//             {
//                 return;   // DB has been seeded
//             }
//             context.Reservation.AddRange(
//                 new Reservation
//                 {
//                     Id = 1,
//                     StartDate = DateTime.Parse("2024-10-08"),
//                     EndDate = DateTime.Parse("2024-10-10"),
//                     StatusId = 1
//                 },
//                 new Reservation
//                 {
//                     Id = 2,
//                     StartDate = DateTime.Parse("2024-10-21"),
//                     EndDate = DateTime.Parse("2024-10-23"),
//                     StatusId = 2
//                 },
//                 new Reservation
//                 {
//                     Id = 3,
//                     StartDate = DateTime.Parse("2024-10-12"),
//                     EndDate = DateTime.Parse("2024-10-16"),
//                     StatusId = 3
//                 },
//                 new Reservation
//                 {
//                     Id = 4,
//                     StartDate = DateTime.Parse("2024-10-05"),
//                     EndDate = DateTime.Parse("2024-10-02"),
//                     StatusId = 4
//                 }
//             );
//             context.SaveChanges();
//         }
//     }
// }