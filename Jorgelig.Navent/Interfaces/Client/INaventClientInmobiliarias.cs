using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients.Inmobiliarias;

namespace Jorgelig.Navent.Interfaces.Client
{
    public interface INaventClientInmobiliarias
    {
        /// <summary>
        /// Listar todas las inmobiliarias vinculadas
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="size">Cantidad de objetos por pagina. Defalut: 100, Maximo: 100, Minimo: 0</param>
        /// <param name="page">Numero de la pagina. Default: 0, Minimo: 0</param>
        /// <returns></returns>
        Task<InmobiliariasPagableResponse> Search(string token, InmobiliariasPagableRequest request);

        /// <summary>
        /// Desvincular una inmobiliaria
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="codigoInmobiliaria">Código de la inmobiliaria en el sistema del integrador</param>
        /// <returns></returns>
        /// <see cref="https://open.navent.com/api-reference/api_endpoints/inmobiliarias/deleteinmobiliariausingdelete-1"/>
        Task<string> DeleteInmobiliarias(string token, string codigoInmobiliaria);

        /// <summary>
        /// Calidad de una inmobiliaria
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <param name="codigoInmobiliaria">Código de la inmobiliaria en el sistema del integrador</param>
        /// <returns></returns>
        /// <see cref="https://open.navent.com/api-reference/api_endpoints/inmobiliarias/getcalidadusingget-31"/>
        Task<InmobiliariasCalidadResponse> GetInmobiliariaCalidad(string token, string codigoInmobiliaria);
    }

}