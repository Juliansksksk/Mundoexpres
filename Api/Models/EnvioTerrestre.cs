using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class EnvioTerrestre
    {

        public int EnvioTerrestreId { get; set; }
        public int TipoProductoId { get; set; }
        public int ClienteId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int BodegaEntregaId { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string PlacaVehiculo { get; set; }
        public string NumeroGuia { get; set; }

    }
}