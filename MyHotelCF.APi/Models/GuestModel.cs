using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelCF.APi.Models
{
    public class GuestModel
    {
        public int Id { get; set; }
        public int PassportId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is GuestModel)
            {
                var objSM = obj as GuestModel;
                return this.Id == objSM.Id
                       && this.FullName == objSM.FullName
                       && this.PassportId == objSM.PassportId
                       && this.Address == objSM.Address
                       && this.Birthday == objSM.Birthday;
            }
            else
            {
                return base.Equals(obj);
            }

        }
    }
}