using System;
using System.Threading.Tasks;
using Jorgelig.Navent.HttpClients.Inmobiliarias;

// ReSharper disable once CheckNamespace
namespace Jorgelig.Navent.HttpClients
{
    public partial class NaventClient
    {
        public Task<InmobiliariasPagableResponse> Search(string token, int size, int page)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteInmobiliarias(string token, string codigoInmobiliaria)
        {
            throw new NotImplementedException();
        }

        public Task<InmobiliariasCalidadResponse> GetInmobiliariaCalidad(string token, string codigoInmobiliaria)
        {
            throw new NotImplementedException();
        }

        public Task<InmobiliariasPagableResponse> Search(string token, InmobiliariasPagableRequest request)
        {
            throw new NotImplementedException();
        }
    }
}