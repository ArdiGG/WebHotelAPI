using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.BLL.DTO;
using MyHotel.DAL.Entities;

namespace MyHotel.BLL.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetAllBookings();
        BookingDTO Get(int id);
        void Post(Booking booking);
        void Delete(int id);
        void Put(int id, Booking booking);
    }
}
