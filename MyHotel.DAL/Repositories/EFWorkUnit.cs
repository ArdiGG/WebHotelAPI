using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.EF;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;

namespace MyHotel.DAL.Repositories
{
    public class EFWorkUnit : IWorkUnit
    {
        private Hotel db;
        private GuestRepository guestRepository;
        private RoomRepository roomRepository;
        private BookingRepository bookingRepository;
        private RoomCategoryRepository roomCategoryRepository;
        public EFWorkUnit(string connectionString)
        {
            db = new Hotel(connectionString);
        }

        public IRepository<RoomCategory> RoomCategories
        {
            get
            {
                if (roomCategoryRepository == null)
                {
                    roomCategoryRepository = new RoomCategoryRepository(db);
                }

                return roomCategoryRepository;
            }
        }
        public IRepository<Guest> Guests
        {
            get
            {
                if (guestRepository == null)
                {
                    guestRepository = new GuestRepository(db);
                }

                return guestRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                {
                    roomRepository = new RoomRepository(db);
                }

                return roomRepository;
            }
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepository == null)
                {
                    bookingRepository = new BookingRepository(db);
                }

                return bookingRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
