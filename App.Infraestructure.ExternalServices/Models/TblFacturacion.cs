using System;
using System.Collections.Generic;

#nullable disable

namespace App.Infraestructure.ExternalServices.Models
{
    public partial class TblFacturacion
    {
        public string IdTransaccion { get; set; }
        public string FldNumeroTarjeta { get; set; }
        public string FldFechaExpiracion { get; set; }
        public string FldCvc { get; set; }
        public string FldNombre { get; set; }
        public string FldPedido { get; set; }
        public decimal FldPrecioTotal { get; set; }
        public string FldCodigoRespuesta { get; set; }
    }
}
