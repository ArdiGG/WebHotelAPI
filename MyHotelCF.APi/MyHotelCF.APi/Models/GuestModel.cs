using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelCF.APi.Models
{
    public class GuestModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
    }
}