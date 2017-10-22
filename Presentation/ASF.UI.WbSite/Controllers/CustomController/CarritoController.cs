using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants.CarritoCompra;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Controllers
{
   
    public class CarritoController : Controller, IABMControlador<CartItem>
    {

        private readonly IABMProcess<CartItem> _abmProcess;
        // GET: Carrito

        public CarritoController()
        {
            this._abmProcess = new ProcessComponent<CartItem>();

        }

        public ActionResult AñadirCarrito(int id)
        {
            try
            {

                _abmProcess.Create()

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }



        }


        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}