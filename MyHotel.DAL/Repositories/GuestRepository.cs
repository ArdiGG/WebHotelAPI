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
    class GuestRepository : IRepository<Guest>
    {
        private Hotel db;

        public GuestRepository(Hotel db)
        {
            this.db = db;
        }

        public IEnumerable<Guest> GetAll()
        {
            return db.Guests;
        }

        public Guest Get(int id)
        {
            return db.Guests.Find(id);
        }

        public void Add(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
        }
        public void Put(int id, Guest guest)
        {
            var oldGuest = db.Guests.Find(id);
            oldGuest.FullName = guest.FullName;
            oldGuest.Address = guest.Address;
            oldGuest.Birthday = guest.Birthday;
            oldGuest.PassportId = guest.PassportId;
            db.Entry(oldGuest).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Guest guest = Get(id);
            if(guest != null)
                db.Guests.Remove(guest);
            db.SaveChanges();
        }
    }
}
