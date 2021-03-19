using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jorgelig.Navent.HttpClients.Avisos
{
    public class AvisosDeveloperPagableRequest
    {
        [JsonProperty(PropertyName = "idInmobiliariaNavplat")]
        public int IdInmobiliaria{ get; set; }

        [JsonProperty(PropertyName = "idAvisoNavplat")]
        public int IdAviso{ get; set; }
        public string CodigoAviso { get; set; }
        /// <summary>
        /// Id de la ubiacion a buscar. Ejemplo: V1-E-100233. Se pueden enviar varios separados por coma: valor[,valor]
        /// </summary>
        public string IdUbicacion { get; set; }
        /// <summary>
        /// Titulo del aviso a buscar.
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Id tipo de propiedad. Se pueden enviar varios separados por coma: valor[,valor]
        /// </summary>
        public string IdTipoPropiedad { get; set; }
        /// <summary>
        /// Tipo de operacion. Se pueden enviar varios separados por coma: valor[,valor]
        /// </summary>
        public string Operacion { get; set; }
        /// <summary>
        /// Precio base del aviso o avisos a buscar.
        /// </summary>
        public int PrecioDesde { get; set; }
        /// <summary>
        /// Precio tope del aviso o avisos a buscar.
        /// </summary>
        public int PrecioHasta { get; set; }
        /// <summary>
        /// Moneda de la operacion. Buscar opciones en /v1/monedas
        /// </summary>
        /// <see cref="XXXXXXX"/>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Tipo de posting: PROPERTY (aviso), DEVELOPMENT (desarrollo), ALL (todos). Este parámetro no es tenido en cuenta.
        /// </summary>
        public string PostingType { get; set; }
        /// <summary>
        /// Cantidad de desarrollos se desea en el resultado. Este parámetro no es tenido en cuenta.
        /// </summary>
        public int DevelopmentQuantity { get; set; }



        [JsonProperty(PropertyName = "pageable.size")]
        public int Size { get; set; } = 100;
        [JsonProperty(PropertyName = "pageable.page")]
        public int Page { get; set; } = 0;
        [JsonProperty(PropertyName = "access_token")]
        public string? AccessToken { get; set; }
    }
}
