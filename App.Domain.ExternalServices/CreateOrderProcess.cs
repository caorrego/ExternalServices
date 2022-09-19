using App.Domain.ExternalServices.Models;
using App.Infraestructure.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ExternalServices
{
    public class CreateOrderProcess : ICreateOrderProcess
    {
        public ResponseCrearPedido sendOrder(dbTuyaContext dbContex, RequestCrearPedido req)
        {
            TblPedido order = new TblPedido();
            try
            {
                order.IdTransaccion = req.IdTransaction;
                order.FldPrecioTotal = req.Price;
                order.FldPedido = req.Order;
                order.FldFechaOrden = req.OrderDate;
                order.FldFechaEntrega = req.OrderDate.AddDays(3);
                order.FldEstadoEnvio = "Enviado";

                dbContex.TblPedidos.Add(order);
                dbContex.SaveChanges();

                return new ResponseCrearPedido { IdTransaction = order.IdTransaccion, DateDelivery = order.FldFechaOrden, Message = "pedido exitoso", ResponseCode = "00", StatusDelivery = order.FldEstadoEnvio };
            }
            catch(Exception ex)
            {
                return new ResponseCrearPedido { IdTransaction = "0", DateDelivery = null, Message = ex.Message + "----" + ex.StackTrace, ResponseCode = "99", StatusDelivery = "No enviado" };
            }

        }
    }
}
