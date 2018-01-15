using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Administration_short",
                "admin",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Login",
                "login",
                new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}