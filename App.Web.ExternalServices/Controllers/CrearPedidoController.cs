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
    public class CrearPedidoController : Controller
    {
        dbTuyaContext _dbContext;
        ICreateOrderProcess _createOrderProcess;
        public CrearPedidoController(dbTuyaContext dbContext, ICreateOrderProcess createOrderProcess)
        {
            this._dbContext = dbContext;
            this._createOrderProcess = createOrderProcess;
        }

        [HttpPost]
        public IActionResult CreacionPedido(RequestCrearPedido req)
        {
            return Ok(_createOrderProcess.sendOrder(_dbContext, req));
        }
    }
}
