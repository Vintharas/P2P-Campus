using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Ninject;
using P2P_Campus.Data.Infrastructure;
using P2P_Campus.Data.Interfaces;
using P2P_Campus.Infrastructure;

namespace P2P_Campus
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private StandardKernel ninjectKernel;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        /// <summary>
        /// Handle on Application Start event
        /// </summary>
        protected void Application_Start()
        {
            RegisterDependencyResolver();
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            // Inject account repository into our custom membership provider.
            ninjectKernel.Inject(Membership.Provider);
            ninjectKernel.Inject(Roles.Provider);
        }

        /// <summary>
        /// Register custom dependency resolver
        /// </summary>
        private void RegisterDependencyResolver()
        {
            ninjectKernel = new StandardKernel();
            SetupNinject();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(ninjectKernel));
        }

        /// <summary>
        /// Setup ninject DI container
        /// </summary>
        private void SetupNinject()
        {
            // Configure associations between abstractions and concrete classes
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IRoleRepository>().To<RoleRepository>();
        }
    }
}