using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;

namespace MyHotel.BLL.Services
{
    public class RoomService : IRoomService
    {
        private IWorkUnit Database { get; set; }

        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Room, RoomDTO>();
            cfg.CreateMap<RoomCategory, RoomCategoryDTO>();
        });

        public RoomService(IWorkUnit database)
        {
            this.Database = database;
        }
        public void Post(Room room)
        {
            Database.Rooms.Add(room);
        }
        public void Put(int id, Room room)
        {
            Database.Rooms.Put(id, room);
        }
        public IEnumerable<RoomDTO> GetAllRooms()
        {
            var mapper = config.CreateMapper();

            return mapper.Map<IEnumerable<Room>, List<RoomDTO>>(Database.Rooms.GetAll());
        }
        public void Delete(int id)
        {
            Database.Rooms.Delete(id);
        }
        public RoomDTO Get(int id)
        {
            var room = Database.Rooms.Get(id);
            var mapper = config.CreateMapper();
            return mapper.Map<Room, RoomDTO>(room);
        }
    }
}
