using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DAL.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public bool Set { get; set; }
        [ForeignKey("GuestId")]
        public virtual Guest BookingGuest { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room BookingRoom { get; set; }
    }
}
