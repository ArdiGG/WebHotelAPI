using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.BLL.DTO;
using MyHotel.DAL.Entities;

namespace MyHotel.BLL.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAllRooms();
        RoomDTO Get(int id);
        void Post(Room room);
        void Delete(int id);
        void Put(int id, Room room);
    }
}
