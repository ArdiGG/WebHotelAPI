using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.Entities;

namespace MyHotel.DAL.EF
{
    public class Hotel : DbContext
    {
        public Hotel() : base("name=Hotel")
        {
            Database.SetInitializer<Hotel>(new MyHotelInitializer());
        }

        public Hotel(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<Hotel>(new MyHotelInitializer());
        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
    }

}
