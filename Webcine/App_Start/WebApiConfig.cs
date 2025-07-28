using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Webcine
{
    /// <summary>
    /// Proporciona la configuración para las rutas y servicios de Web API.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registra la configuración y las rutas de Web API.
        /// </summary>
        /// <param name="config">Configuración de HTTP para la aplicación.</param>
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            var cors = new EnableCorsAttribute("http://localhost:5173", "*", "*");
            config.EnableCors(cors);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
