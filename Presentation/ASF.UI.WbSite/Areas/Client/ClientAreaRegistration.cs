using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Client_default",
                "Client/Client/ListEntity",
                new { controller = "Client", action = "ListEntity", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Client",
                "Client/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}