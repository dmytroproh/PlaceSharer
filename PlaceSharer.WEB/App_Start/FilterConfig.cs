using System.Web;
using System.Web.Mvc;
using PlaceSharer.WEB.Filters;

namespace PlaceSharer.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CultureAttribute());
        }
    }
}
