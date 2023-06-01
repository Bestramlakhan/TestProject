using System.Web;
using System.Web.Mvc;

namespace Machine_test__Euphoria_infotech
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
