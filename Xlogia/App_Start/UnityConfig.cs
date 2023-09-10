using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Xlogia.Domain.Abstract;
using Xlogia.Domain.Concrete;

namespace Xlogia
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeRepository, EFEmployeeRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}