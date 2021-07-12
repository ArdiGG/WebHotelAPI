using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.BLL.DTO
{
    public class RoomCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bed { get; set; }
        public float Price { get; set; }
    }
}
