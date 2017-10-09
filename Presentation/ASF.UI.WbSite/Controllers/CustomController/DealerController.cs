using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers.CustomController
{
    public class DealerController : Controller, IABMControlador<Dealer>
    {
        private IABMProcess<Dealer> _abmProcess;

        public DealerController()
        {
            
            this._abmProcess = new ProcessComponent<Dealer>();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dealer entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Delete(Dealer entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(object id)
        {
            try
            {

                var cliente = _abmProcess.GetById(id.ToString());


                //var categorias = new ProcessComponent<Country>()
                //    .SelectList().Select(c => new Country() { Id = c.Id, Name = c.Name })
                //    .ToList();



                // ViewBag.CategoryId = new SelectList(categorias, "Id", "Name");
                return View(cliente);



            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }
        }


        [HttpPost]
        public ActionResult Edit(Dealer entity)
        {
            throw new NotImplementedException();
        }

        // GET: Dealer
        public ActionResult Index()
        {
            try
            {
                var _dealer = _abmProcess.SelectList();

                return View(_dealer);
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }
    }
}