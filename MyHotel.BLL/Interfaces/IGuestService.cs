using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.BLL.DTO;
using MyHotel.DAL.Entities;

namespace MyHotel.BLL.Interfaces
{
    public interface IGuestService
    {
        IEnumerable<GuestDTO> GetAllGuests();
        GuestDTO Get(int id);
        void Post(GuestDTO newGuest);
        void Put(int id,Guest guest);
        void Delete(int id);
    }
}
