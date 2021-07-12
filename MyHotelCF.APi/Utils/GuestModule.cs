using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotel.BLL.Interfaces;
using MyHotel.BLL.Services;
using Ninject.Modules;

namespace MyHotelCF.APi.Utils
{
    public class GuestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGuestService>().To<GuestService>();
        }
    }
}