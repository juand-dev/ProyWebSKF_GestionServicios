using System.Web;
using System.Web.Mvc;

namespace ProyWebSKF_GestionServicios
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
