using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Coordinators
{
    public class CoordinatorsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Coordinators";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Coordinators_default",
                "Coordinators/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}