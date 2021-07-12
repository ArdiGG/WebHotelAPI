using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelCF.APi.Models
{
    public class RoomCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bed { get; set; }
        public float Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RoomCategoryModel)
            {
                var objSM = obj as RoomCategoryModel;
                return this.Id == objSM.Id
                       && this.Bed == objSM.Bed
                       && this.Name == objSM.Name
                       && this.Price == objSM.Price;
            }
            else
            {
                return base.Equals(obj);
            }

        }
    }
}