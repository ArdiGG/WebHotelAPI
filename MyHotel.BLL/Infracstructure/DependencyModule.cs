using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.Interfaces;
using Ninject.Modules;
using MyHotel.DAL.Repositories;

namespace MyHotel.BLL.Infracstructure
{
    public class DependencyModule : NinjectModule
    {
        private string connectionString;

        public DependencyModule(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IWorkUnit>().To<EFWorkUnit>().WithConstructorArgument(connectionString);
        }
    }
}
