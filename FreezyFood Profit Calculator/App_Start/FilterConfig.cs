using System.Web;
using System.Web.Mvc;

namespace FreezyFood_Profit_Calculator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //application level autorization
            filters.Add(new AuthorizeAttribute { Roles = "Admin" });
        }
    }
}
