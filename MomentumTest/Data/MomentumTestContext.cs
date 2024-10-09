using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MomentumTest.Models;

namespace MomentumTest.Data
{
    public class MomentumTestContext(DbContextOptions<MomentumTestContext> options) : DbContext(options)
    {
        public DbSet<MomentumTest.Models.Reservation> Reservation { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.MainGuest)
                .WithMany(g => g.Reservations)
                .HasForeignKey(r => r.MainGuestId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Status)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.StatusId);
        }
    }
}
