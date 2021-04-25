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
    }
}