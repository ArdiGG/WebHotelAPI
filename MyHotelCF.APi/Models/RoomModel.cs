using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotel.BLL.DTO;

namespace MyHotelCF.APi.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomCategoryDTO Category { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RoomModel)
            {
                var objSM = obj as RoomModel;
                return this.Id == objSM.Id
                       && this.RoomNumber == objSM.RoomNumber
                       && this.Category == objSM.Category;
            }
            else
            {
                return base.Equals(obj);
            }

        }
    }
}