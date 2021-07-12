using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BLL.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomCategoryDTO Category { get; set; }

    }
}
