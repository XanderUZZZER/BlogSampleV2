using BlogSampleV2.WebUI.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSampleV2.WebUI
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      //Dependency injection
      NinjectModule registrations = new NinjectRegistrations();
      var kernel = new StandardKernel(registrations);
      DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
    }
  }
}
