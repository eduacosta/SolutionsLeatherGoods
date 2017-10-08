using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ASF.UI.WbSite.Constants.CarritoCompra;

namespace ASF.UI.WbSite.Controllers
{
    [RoutePrefix("Carrito")]
    public class CarritoController : Controller
    {
        [Route("CarritoCompra")]
        // GET: Carrito
        public ActionResult CarritoCompra()
        {
            return View();
        }
    }
}