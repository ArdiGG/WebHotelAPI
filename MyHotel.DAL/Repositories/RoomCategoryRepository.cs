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
    public class RoomCategoryRepository : IRepository<RoomCategory>
    {
        private Hotel db;

        public RoomCategoryRepository(Hotel db)
        {
            this.db = db;
        }

        public IEnumerable<RoomCategory> GetAll()
        {
            return db.RoomCategories;
        }

        public RoomCategory Get(int id)
        {
            return db.RoomCategories.Find(id);
        }

        public void Add(RoomCategory roomCategory)
        {
            db.RoomCategories.Add(roomCategory);
            db.SaveChanges();
        }

        public void Put(int id, RoomCategory roomCategory)
        {
            var oldRoomCategory = db.RoomCategories.Find(id);
            oldRoomCategory.Bed = roomCategory.Bed;
            oldRoomCategory.Name = roomCategory.Name;
            oldRoomCategory.Price = roomCategory.Price;
            db.Entry(oldRoomCategory).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            RoomCategory roomCategory = Get(id);
            if (roomCategory != null)
                db.RoomCategories.Remove(roomCategory);
            db.SaveChanges();
        }
    }
}
