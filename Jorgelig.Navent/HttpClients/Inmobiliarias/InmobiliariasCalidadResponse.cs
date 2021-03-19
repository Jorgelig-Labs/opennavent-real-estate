namespace Jorgelig.Navent.HttpClients.Inmobiliarias
{
    public class InmobiliariasCalidadResponse
    {
        public string? Status { get; set; }
        public string? CodigoInmobiliaria { get; set; }
        public int? MaxPorcentajeCalidad { get; set; }
        public int? AvisosConAltaCalidad { get; set; }
        public int? avisosDuplicados { get; set; }
        public int? avisosConMediaCalidad { get; set; }
        public int? avisosOnline { get; set; }
        public int? minPorcentajeCalidad { get; set; }
        public InmobiliariasAvisoPeorCalidad[] AvisosConPeorCalidad { get; set; }
        public string? IdNavplat { get; set; }
        public string? Nombre { get; set; }
        public int? PromedioPorcentajeCalidad{ get; set; }
        public int? AvisosConBajaCalidad { get; set; }
    }

    public class InmobiliariasAvisoPeorCalidad
    {
        public string? CodigoAviso { get; set; }
        public InmobiliariasAvisoPeorCalidadValidacion Validaciones { get; set; }
        public string? IdAvisoNavplat { get; set; }
        public string? mensajeCalidadM{ get; set; }
        public int? PorcentajeCalidad { get; set; }
        public string? StatusCalidad { get; set; }
    }

    public class InmobiliariasAvisoPeorCalidadValidacion
    {
        public string Status { get; set; }
    }
    
}
