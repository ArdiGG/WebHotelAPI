using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.Entities;

namespace MyHotel.DAL.Interfaces
{
    public interface IWorkUnit
    {
        IRepository<Guest> Guests { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<RoomCategory> RoomCategories { get; }
        void Save();
    }
}
