using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BLL.DTO
{
    public class GuestDTO
    {
        public int Id{ get; set; }
        public int PassportId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }

    }
}
