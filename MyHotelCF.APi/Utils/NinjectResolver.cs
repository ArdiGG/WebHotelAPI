using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace MyHotelCF.APi.Utils
{
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;
        public NinjectScope(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public void Dispose()
        {
            IDisposable disposable = (IDisposable) resolutionRoot;
            if(disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0],true,true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0],true,true);
            return resolutionRoot.Resolve(request).ToList();
        }
    }
    public class NinjectResolver : NinjectScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel.BeginBlock());
        }
    }
}