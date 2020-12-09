using CircularManagementSystem.BL;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace CircularManagementSystem.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IDepartmentBL, DepartmentBL>();
            container.RegisterType<IEmployeeBL, EmployeeBL>();
            container.RegisterType<ICircularBL, CircularBL>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}