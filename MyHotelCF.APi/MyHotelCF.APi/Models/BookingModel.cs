using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotel.DAL.Entities;

namespace MyHotelCF.APi.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public GuestModel BookingGuest { get; set; }
        public RoomModel BookingRoom { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? DepartureTime { get; set; }
    }
}