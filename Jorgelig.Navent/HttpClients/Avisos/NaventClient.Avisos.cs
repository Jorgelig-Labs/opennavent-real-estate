using System;
using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients.Avisos;
using Jorgelig.Navent.Interfaces;
using Jorgelig.Navent.Interfaces.Client;

namespace Jorgelig.Navent.HttpClients
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="INaventClientAvisos"/>
    public partial class NaventClient
    {
        public Task<string> GetResumen(string? token, string codigoInmobiliaria, AvisosDeveloperPagableRequest queryParameters)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAvisosStatus(string? token, string? codigoInmobiliaria, string? codigoAviso)
        {
            throw new NotImplementedException();
        }

        public Task<string> CrearOModificarDesarrollo(string? token, string? codigoInmobiliaria, string? codigoDesarrollo)
        {
            throw new NotImplementedException();
        }
    }
}