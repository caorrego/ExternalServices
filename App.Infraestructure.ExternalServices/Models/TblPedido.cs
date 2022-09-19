using System;
using System.Collections.Generic;

#nullable disable

namespace App.Infraestructure.ExternalServices.Models
{
    public partial class TblPedido
    {
        public string IdTransaccion { get; set; }
        public decimal FldPrecioTotal { get; set; }
        public string FldPedido { get; set; }
        public DateTime FldFechaOrden { get; set; }
        public DateTime FldFechaEntrega { get; set; }
        public string FldEstadoEnvio { get; set; }
    }
}
