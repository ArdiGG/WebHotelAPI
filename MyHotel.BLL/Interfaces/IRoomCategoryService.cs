using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.BLL.DTO;
using MyHotel.DAL.Entities;

namespace MyHotel.BLL.Interfaces
{
    public interface IRoomCategoryService
    {
        IEnumerable<RoomCategoryDTO> GetAllRoomCategories();
        RoomCategoryDTO Get(int id);
        void Post(RoomCategoryDTO roomCategory);
        void Put(int id ,RoomCategory roomCategory);
        void Delete(int id);
    }
}
