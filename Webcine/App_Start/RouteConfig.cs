using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webcine
{
    /// <summary>
    /// Configuración de rutas para la aplicación Webcine.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registra las rutas de la aplicación.
        /// </summary>
        /// <param name="routes">Colección de rutas a configurar.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
