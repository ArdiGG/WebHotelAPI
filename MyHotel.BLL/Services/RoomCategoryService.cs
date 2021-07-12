using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using AutoMapper;
using MyHotel.DAL.Interfaces;

namespace MyHotel.BLL.Services
{
    public class RoomCategoryService : IRoomCategoryService
    {
        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RoomCategory, RoomCategoryDTO>();
        });

        private IWorkUnit Database { get; set; }

        public RoomCategoryService(IWorkUnit database)
        {
            this.Database = database;
        }

        public void Delete(int id)
        {
            Database.RoomCategories.Delete(id);
        }
        public void Put(int id, RoomCategory roomCategory)
        {
            Database.RoomCategories.Put(id, roomCategory);
        }
        public void Post(RoomCategoryDTO roomCategory)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomCategoryDTO, RoomCategory>();
            }).CreateMapper();
            Database.RoomCategories.Add(mapper.Map<RoomCategoryDTO,RoomCategory>(roomCategory));
        }
        public IEnumerable<RoomCategoryDTO> GetAllRoomCategories()
        {

            var data = Database.RoomCategories.GetAll();
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<RoomCategory>, List<RoomCategoryDTO>>(data);
        }

        public RoomCategoryDTO Get(int id)
        {
            var roomCategory = Database.RoomCategories.Get(id);
            var mapper = config.CreateMapper();
            return mapper.Map<RoomCategory, RoomCategoryDTO>(roomCategory);
        }
    }
}
