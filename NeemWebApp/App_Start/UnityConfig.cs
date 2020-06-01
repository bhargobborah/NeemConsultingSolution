using NeemDataAccess.Interfaces;
using NeemDataAccess.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace NeemWebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}