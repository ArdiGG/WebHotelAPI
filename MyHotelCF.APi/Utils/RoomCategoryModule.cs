using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotel.BLL.Interfaces;
using MyHotel.BLL.Services;
using Ninject.Modules;

namespace MyHotelCF.APi.Utils
{
    public class RoomCategoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoomCategoryService>().To<RoomCategoryService>();
        }
    }
}