using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.EF;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;

namespace MyHotel.DAL.Repositories
{
    class BookingRepository : IRepository<Booking>
    {
        private Hotel db;

        public BookingRepository(Hotel db)
        {
            this.db = db;
        }

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings;
        }

        public Booking Get(int id)
        {
            return db.Bookings.Find(id);
        }

        public void Add(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
        public void Put(int id, Booking booking)
        {
            var oldBooking = db.Bookings.Find(id);

            oldBooking.ArriveDate = booking.ArriveDate;
            oldBooking.DepartureDate = booking.DepartureDate;
            oldBooking.BookingDate = booking.BookingDate;
            oldBooking.RoomId = booking.RoomId;
            oldBooking.GuestId = booking.GuestId;
            oldBooking.Set = booking.Set;

            db.Entry(oldBooking).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Booking booking = Get(id);
            if (booking != null)
                db.Bookings.Remove(booking);
            db.SaveChanges();
        }
    }
}
