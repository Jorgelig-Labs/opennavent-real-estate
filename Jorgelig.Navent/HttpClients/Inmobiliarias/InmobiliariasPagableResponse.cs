namespace Jorgelig.Navent.HttpClients.Inmobiliarias
{
    public class InmobiliariasPagableResponse
    {
        public InmobiliariasResponse[] Content { get; set; }
        public int Total { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
    }

    public class InmobiliariasResponse
    {
        public string? CodigoInmobiliaria { get; set; }
        public string? HabilitadoDesde { get; set; }
        public bool? Bloqueada { get; set; }
        public int? IdNavplat { get; set; }
        public string? Nombre { get; set; }
        public object? EmailsPorRol { get; set; }
    }
}
