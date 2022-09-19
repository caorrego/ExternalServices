using App.Domain.ExternalServices.Models;
using App.Infraestructure.ExternalServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ExternalServices
{
    public class BillingProcess : IBillingProcess
    {
        public ResponseFacturacion sendBilling(dbTuyaContext dbContex, RequestPayment req)
        {
            TblFacturacion billing = new TblFacturacion();
            try
            {
                billing.IdTransaccion = idGenerate();
                billing.FldNumeroTarjeta = "************" + req.cardNumber.Substring(12);
                billing.FldFechaExpiracion = req.expirationDate;
                billing.FldCvc = req.cvc;
                billing.FldNombre = req.name;
                billing.FldPedido = JsonConvert.SerializeObject(req.productos);
                billing.FldPrecioTotal = sumProducts(req.productos);
                billing.FldCodigoRespuesta = (req.cvc == "123") ? billing.FldCodigoRespuesta = "00" : billing.FldCodigoRespuesta = "98";

                dbContex.TblFacturacions.Add(billing);
                dbContex.SaveChanges();

                if(billing.FldCodigoRespuesta == "00")
                {
                    return new ResponseFacturacion { IdTransaction = billing.IdTransaccion, Message = "Pago exitoso", ResponseCode = billing.FldCodigoRespuesta, TotalPrice = billing.FldPrecioTotal };
                }
                else
                {
                    return new ResponseFacturacion { IdTransaction = billing.IdTransaccion, Message = "Pago rechazado", ResponseCode = billing.FldCodigoRespuesta, TotalPrice = billing.FldPrecioTotal };
                }
                
            }
            catch(Exception ex)
            {
                return new ResponseFacturacion { IdTransaction = "0", Message = ex.Message + "----" + ex.StackTrace, ResponseCode = "99", TotalPrice = 0 };
            }       
        }

        private string idGenerate()
        {
            Random rand = new Random();
            int firtPart = rand.Next(100000, 999999);
            string secondPart = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

            return firtPart.ToString() + secondPart;
        }

        private decimal sumProducts(List<Product> products)
        {
            decimal total = 0;
            foreach (Product value in products)
            {
                total = total + value.price;
            }
            return total;
        }
    }
}
