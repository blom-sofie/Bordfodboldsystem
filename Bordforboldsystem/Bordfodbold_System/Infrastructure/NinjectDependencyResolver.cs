using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Bordfodbold_System.Abstract;
using Bordfodbold_System.Concrete;
using Ninject;

namespace Bordfodbold_System.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
             _kernel.Bind<IPlayerRepository>().To<EfPlayerRepository>();
             _kernel.Bind<ITeamRepository>().To<EfTeamRepository>();
             _kernel.Bind<IGameRepository>().To<EfGameRepository>();
             _kernel.Bind<IStatisticsRepository>().To<EfStatisticsRepository>();
        }
    }
}