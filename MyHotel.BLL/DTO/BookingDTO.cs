using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.Entities;

namespace MyHotel.BLL.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public GuestDTO BookingGuest { get; set; }
        public RoomDTO BookingRoom { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public bool Set { get; set; }

    }
}
