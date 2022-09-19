using App.Domain.ExternalServices.Models;
using App.Infraestructure.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ExternalServices
{
    public interface ICreateOrderProcess
    {
        public ResponseCrearPedido sendOrder(dbTuyaContext dbContex, RequestCrearPedido req);
    }
}
