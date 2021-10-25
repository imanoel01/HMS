using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Model;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class HMSDbContext:DbContext
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options): base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RoomType> RoomType { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomStatus> RoomStatus { get; set; }
        public DbSet<Reservation> Reservation {get;set;}
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
       public DbSet<Bill> Bill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //        modelBuilder.Entity<Bill>()
    // .HasOne<Room>(b =>b.Room)
    // .WithMany(r => r.Bills)
    // .HasForeignKey(b => b.RoomId)
    // .OnDelete(DeleteBehavior.NoAction);
    //     }

    // modelBuilder.Entity<Room>()
    // .HasOne<Bill>(b =>b.Room)
    // .WithMany(r => r.Bills)
    // .HasForeignKey(b => b.RoomId)
    // .OnDelete(DeleteBehavior.NoAction);
    //     }
        modelBuilder.Entity<RoomStatus>().HasData(
            new RoomStatus { Id = 1, Name = "Confirmed",Description="Once payment method and/or billing instructions are confirmed a reservation status can be selected as confirmed. A reservation should only be confirmed upon receipt of a credit card or deposit payment." },
            new RoomStatus{ Id = 2, Name = "Tentative",Description="If payment method and/or billing instructions have not been guaranteed then the reservation should be set to the status of Tentative." },
            new RoomStatus { Id = 3, Name = "Waitlist",Description="If the hotel or room type is fully booked then the customer should be given the option to waitlist their reservation. " },
            new RoomStatus { Id = 4, Name = "Company Guarantee",Description="If a reservation is made by a company and also billed to the same company then reservation status 'Company guarantee' may be used." },
            new RoomStatus { Id = 5, Name = "Travel Agent Guarantee",Description="A travel agent booking with a valid IATA number and Travel agent voucher may be selected as code Travel Agent Guarantee'." },
            new RoomStatus { Id = 6, Name = "6 PM Release",Description="A reservation is not guaranteed with payment or voucher and the hotel will hold it till 6PM in the evening." });
    }
}

}

