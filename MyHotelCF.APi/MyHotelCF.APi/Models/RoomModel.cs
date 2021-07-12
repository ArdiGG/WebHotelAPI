using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelCF.APi.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public float Price { get; set; }
        public string RoomType { get; set; }
        public int SleepingPlaces { get; set; }
    }
}