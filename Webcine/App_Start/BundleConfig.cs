using System.Web;
using System.Web.Optimization;

namespace Webcine
{
    /// <summary>
    /// Proporciona métodos para registrar los paquetes de scripts y estilos utilizados en la aplicación.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registra los paquetes de scripts y estilos para la aplicación.
        /// </summary>
        /// <param name="bundles">Colección de paquetes a la que se agregarán los nuevos paquetes.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
