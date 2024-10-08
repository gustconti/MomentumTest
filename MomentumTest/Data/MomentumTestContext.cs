using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MomentumTest.Models;

namespace MomentumTest.Data
{
    public class MomentumTestContext : DbContext
    {
        public MomentumTestContext (DbContextOptions<MomentumTestContext> options)
            : base(options)
        {
        }

        public DbSet<MomentumTest.Models.Reservation> Reservation { get; set; } = default!;
    }
}
