using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers.CustomController
{
    public class OrderController : Controller, IABMControlador<Order>
    {

        private ProcessComponent<Order> _processComponent;

        public OrderController()
        {
            
            this._processComponent = new ProcessComponent<Order>();

        }


        [HttpGet]
        public JsonResult Eliminar(int id)

        {
            try
            {
                Thread.Sleep(2000);

                Order _order = new Order();
                _order.Id = id;


                _processComponent.Remove(_order);
                return Json("Orden eliminada Correctamente", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }



        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(Order entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}