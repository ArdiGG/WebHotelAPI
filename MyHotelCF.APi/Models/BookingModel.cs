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
        public DateTime? BookingDate { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public bool Set { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is BookingModel)
            {
                var objSM = obj as BookingModel;
                return this.Id == objSM.Id
                       && this.Set == objSM.Set
                       && this.BookingRoom == objSM.BookingRoom
                       && this.BookingDate == objSM.BookingDate
                       && this.ArriveDate == objSM.ArriveDate
                       && this.BookingGuest == objSM.BookingGuest
                       && this.DepartureDate == objSM.DepartureDate;
            }
            else
            {
                return base.Equals(obj);
            }

        }
    }
}