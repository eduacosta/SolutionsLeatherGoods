using ASF.Entities;
using ASF.UI.Process;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoriasController : Controller, IABMControlador<Category>
    {

        private ProcessComponent<Entities.Category> _categoyprocess;

        public CategoriasController()
        {
            _categoyprocess = new ProcessComponent<Entities.Category>();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category entity)
        {

            try
            {


                entity.CreatedBy = User.Identity.GetUserId();
                _categoyprocess.Create(entity);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }




        public ActionResult Delete(object id)
        {
            try
            {



                var _category = _categoyprocess.GetById(int.Parse(id.ToString()));
                return View(_category);

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }

        }


        [HttpPost]
        public ActionResult Delete(Category entity)
        {
            try
            {
                _categoyprocess.Remove(entity);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }



        public ActionResult Edit(object id)
        {

            try
            {
                var _category = _categoyprocess.GetById(int.Parse(id.ToString()));
                return View(_category);
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }

        }

        [HttpPost]
        public ActionResult Edit(Category entity)
        {
            try
            {
                entity.ChangedBy = User.Identity.GetUserId();
                _categoyprocess.Edit(entity);
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }




        public ActionResult Index()
        {
            try
            {

                var _lista = _categoyprocess.SelectList();
                return View(_lista);

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }
    }
}