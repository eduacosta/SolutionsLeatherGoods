using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using Microsoft.AspNet.Identity;

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

                var dealer = _abmProcess.GetById(id.ToString());


                //var categorias = new ProcessComponent<Country>()
                //    .SelectList().Select(c => new Country() { Id = c.Id, Name = c.Name })
                //    .ToList();

                if(dealer == null)
                    dealer = new Dealer();

                // ViewBag.CategoryId = new SelectList(categorias, "Id", "Name");
                return View(dealer);



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
            try
            {
                entity.AsPNetUsers = User.Identity.GetUserId();
               
                entity.Country = new Country() { Id = entity.CountryId };
                if (entity.Id == 0)
                {
                    entity.CreatedBy = User.Identity.GetUserId();
                    _abmProcess.Create(entity);

                }
                else
                {
                    entity.ChangedBy = User.Identity.GetUserId();
                    _abmProcess.Edit(entity);
                }

                return RedirectToAction("Edit", new { id = entity.AsPNetUsers });
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }
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