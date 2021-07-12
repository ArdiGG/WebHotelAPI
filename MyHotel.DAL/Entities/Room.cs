using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyHotel.DAL.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual RoomCategory Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
