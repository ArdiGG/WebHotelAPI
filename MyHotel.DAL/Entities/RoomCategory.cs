using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyHotel.DAL.Entities
{
    public class RoomCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bed { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<RoomCategory> RoomCategories { get; set; }
    }
}
