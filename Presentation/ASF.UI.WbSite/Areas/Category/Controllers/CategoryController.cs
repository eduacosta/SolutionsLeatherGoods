using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ASF.UI.Process;
using ASF.UI.WbSite.Areas.Category.Models;
using ASF.UI.WbSite.Constants;
using ASF.UI.WbSite.Constants.CategoryController;
using ASF.UI.WbSite.Constants.ErrorController;
using ASF.UI.WbSite.Controllers;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller, IABMControlador<Entities.Category>
    {
        private ProcessComponent<Entities.Category> _categoyprocess;

        public CategoryController()
        {
            _categoyprocess = new ProcessComponent<Entities.Category>();

        }


        // GET: Category/Category

        [System.Web.Mvc.HttpGet]
        public JsonResult AllData()
        {
            var _lista = _categoyprocess.SelectList();
            IEnumerable<object> customers = null;

            return Json(_lista.ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ListaCategory()
        {

            return View();
        }


        public ActionResult ListEntity()
        {
            var _lista = _categoyprocess.SelectList();
            return View(_lista);
        }


        public ActionResult EditEntity(int id)
        {
            var _category = _categoyprocess.GetById(id);
            return View(_category);


        }

        [System.Web.Mvc.HttpPost]
        public ActionResult EditEntity(Entities.Category category)
        {

            var _category = _categoyprocess.EditCategory(category);
            var _lista = _categoyprocess.SelectList();
            return View("ListEntity", _lista);


        }


        public ActionResult CreateEntity()
        {

            return View();

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreateEntity(Entities.Category category)
        {



            if (ModelState.IsValid)
            {
                try
                {

                    _categoyprocess.CreateCategory(category);
                }
                catch (Exception e)
                {
                    return Json(new ResponseHttp() { success = false, errors = e.Message});


                }



            }
            else
            {
                return Json(new ResponseHttp()
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                        .ToString()
                });

                
            }

            return Json(new ResponseHttp(){success = true, redirect = "Category/Category/ListEntity" });

          
        }


        [System.Web.Mvc.HttpGet]
        public ActionResult DeleteEntity(int id)
        {
            var _category = _categoyprocess.GetById(id);

            return View(_category);



        }


        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteEntity(Entities.Category category)
        {
            var _category = _categoyprocess.RemoveCategory(category);

            var _lista = _categoyprocess.SelectList();
            return View("ListEntity", _lista);



        }


      




    }
}