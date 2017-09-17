using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.UI.WbSite.Areas.Category.Models;
using ASF.UI.WbSite.Constants.CategoryController;
using ASF.UI.WbSite.Constants.ErrorController;
using ASF.UI.WbSite.Controllers;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category/Category

        [System.Web.Mvc.HttpGet]
        public JsonResult AllData()
        {
            var _lista = new Process.CategoryProcess().SelectList();
            IEnumerable<object> customers = null;

            return Json(_lista.ToList(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ListaCategory()
        {

            return View();
        }


        public ActionResult ListCategory()
        {
            var _lista = new Process.CategoryProcess().SelectList();
            return View(_lista);
        }


        public ActionResult EditCategory(int id)
        {
            var _category = new CategoryProcess().GetById(id);
            return View(_category);


        }

        [System.Web.Mvc.HttpPost]
        public ActionResult EditCategory(Entities.Category category)
        {

            var _category = new CategoryProcess().EditCategory(category);
            var _lista = new Process.CategoryProcess().SelectList();
            return View("ListCategory", _lista);


        }


        public ActionResult CreateCategory()
        {

            return View();

        }

        [System.Web.Mvc.HttpPost]
        public JsonResult CreateCategory(Entities.Category category)
        {



            if (ModelState.IsValid)
            {
                try
                {

                    new CategoryProcess().CreateCategory(category);
                }
                catch (Exception e)
                {
                    return Json(new
                    {
                        success = false,
                        errors = e.Message
                    });


                }



            }
            else
            {
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()

                });

              
            }
            return Json(new
            {
                success = true,

            }); ;

        }


        [System.Web.Mvc.HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var _category = new CategoryProcess().GetById(id);

            return View(_category);



        }


        [System.Web.Mvc.HttpPost]
        public ActionResult DeleteCategory(Entities.Category category)
        {
            var _category = new CategoryProcess().RemoveCategory(category);

            var _lista = new Process.CategoryProcess().SelectList();
            return View("ListCategory", _lista);



        }




    }
}