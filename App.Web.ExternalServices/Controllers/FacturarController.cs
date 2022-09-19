using App.Domain.ExternalServices;
using App.Domain.ExternalServices.Models;
using App.Infraestructure.ExternalServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ExternalServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturarController : Controller
    {
        dbTuyaContext _dbContext;
        IBillingProcess _billingProcess;
        public FacturarController(dbTuyaContext dbContext, IBillingProcess billingProcess)
        {
            this._dbContext = dbContext;
            this._billingProcess = billingProcess;
        }
        [HttpPost]
        public IActionResult Facturacion(RequestPayment req)
        {
            return Ok(_billingProcess.sendBilling(_dbContext,req));
        }
    }
}
