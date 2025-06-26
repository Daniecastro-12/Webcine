using System.Web;
using System.Web.Mvc;

namespace Webcine
{
    /// <summary>
    /// Proporciona métodos para registrar filtros globales en la aplicación.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registra los filtros globales en la colección especificada.
        /// </summary>
        /// <param name="filters">La colección de filtros globales.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
