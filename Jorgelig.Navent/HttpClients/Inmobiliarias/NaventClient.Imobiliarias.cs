using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Jorgelig.Navent.Extensions;
using Jorgelig.Navent.HttpClients.Inmobiliarias;
using Serilog.Events;

// ReSharper disable once CheckNamespace
namespace Jorgelig.Navent.HttpClients
{
    public partial class NaventClient
    {
        public async Task<InmobiliariasPagableResponse> Search(string token, int size, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteInmobiliarias(string token, string codigoInmobiliaria)
        {
            throw new NotImplementedException();
        }

        public async Task<InmobiliariasCalidadResponse> GetInmobiliariaCalidad(string token, string codigoInmobiliaria)
        {
            throw new NotImplementedException();
        }

        public async Task<InmobiliariasPagableResponse> Search(InmobiliariasPagableRequest request)
        {
            _log.Enter(
                LogEventLevel.Debug,
                arguments: new object?[]{ request }
                );
            if (request == null) throw new ArgumentNullException(nameof(request));
            try
            {
                
                var url = $"{NaventResourcePath.Inmobiliarias}?access_token={request.AccessToken}&pageable.size={request.Size}&pageable.page={request.Page}";
                var result = await _restClient.ExecuteApi<InmobiliariasPagableResponse>(
                    HttpMethod.Get, 
                    url, 
                    data: request);

                _log.Exit(
                    LogEventLevel.Debug,
                    arguments: new object?[] {request},
                    returnValue: result
                );

                return result;
            }
            catch (Exception ex)
            {
                _log.Exception(
                    LogEventLevel.Error,
                    arguments: new object?[]{ request},
                    exception: ex
                    );
            }

            return default;
        }
    }
}