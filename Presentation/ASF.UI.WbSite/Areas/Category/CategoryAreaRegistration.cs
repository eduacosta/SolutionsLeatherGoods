using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Category
{
    public class CategoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Category";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Category_default",
                "Category/Category/ListEntity",
                new { controller = "Category", action = "ListEntity", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Category5",
                "Category/{controller}/{action}/{id}", new {id=UrlParameter.Optional}
            );

        }
    }
}