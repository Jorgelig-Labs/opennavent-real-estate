using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients.Avisos;

namespace Jorgelig.Navent.Interfaces.Client
{
    public interface INaventClientAvisos
    {
        /// <summary>
        /// AVISO: Puede existir una demora en la actualización de los datos con respecto a las últimas modificaciones. Integración: Lectura Y Escritura / Solo Lectura
        /// </summary>
        /// <param name="token"></param>
        /// <param name="codigoInmobiliaria">Código de la inmobiliaria en el sistema del integrador</param>
        /// <param name="queryParameters">Query Parameters</param>
        /// <returns></returns>
        ///<see cref="https://open.navent.com/api-reference/api_endpoints/avisos/getdevelopmentsusingget-8"/>
        Task<string> GetResumen(string? token, string codigoInmobiliaria, AvisosDeveloperPagableRequest queryParameters);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="codigoInmobiliaria">Código de la inmobiliaria en el sistema del integrador</param>
        /// <param name="codigoAviso">Código del aviso en el sistema del integrador</param>
        /// <returns></returns>
        /// <see cref="https://open.navent.com/api-reference/api_endpoints/avisos/getstatususingget-15"/>
        Task<string> GetAvisosStatus(string? token, string? codigoInmobiliaria, string? codigoAviso);

        /// <summary>
        /// Aviso de desarrollo nuevo
        /// </summary>
        /// <param name="token"></param>
        /// <param name="codigoInmobiliaria">Código de la inmobiliaria en el sistema del integrador</param>
        /// <param name="codigoDesarrollo">Código del desarrollo en el sistema del integrador</param>
        /// <returns></returns>
        Task<string> CrearOModificarDesarrollo(string? token, string? codigoInmobiliaria, string? codigoDesarrollo);
    }


}