using App.Domain.ExternalServices.Models;
using App.Infraestructure.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.ExternalServices
{
    public interface IBillingProcess
    {
        public ResponseFacturacion sendBilling(dbTuyaContext dbContex, RequestPayment req);
    }
}
