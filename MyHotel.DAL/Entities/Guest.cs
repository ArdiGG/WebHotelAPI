using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyHotel.DAL.Entities
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        public int PassportId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
