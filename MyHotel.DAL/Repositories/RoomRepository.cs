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
    class RoomRepository : IRepository<Room>
    {
        private Hotel db;

        public RoomRepository(Hotel db)
        {
            this.db = db;
        }

        public IEnumerable<Room> GetAll()
        {
            return db.Rooms;
        }

        public Room Get(int id)
        {
            return db.Rooms.Find(id);
        }

        public void Put(int id, Room room)
        {
            var oldRoom = db.Rooms.Find(id);

            oldRoom.RoomNumber = room.RoomNumber;
            oldRoom.CategoryId = room.CategoryId;

            db.Entry(oldRoom).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Add(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = Get(id);
            if (room != null)
                db.Rooms.Remove(room);
            db.SaveChanges();
        }
    }
}
