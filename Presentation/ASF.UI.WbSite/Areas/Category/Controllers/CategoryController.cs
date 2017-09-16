using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        [HttpGet]
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

        [HttpPost]
        public ActionResult EditCategory(Entities.Category category)
        {
            
            var _category = new CategoryProcess().EditCategory(category);
            var _lista = new Process.CategoryProcess().SelectList();
            return View("ListCategory", _lista);


        }

        
        public ActionResult CreateCategory()
        {
            
            return View( );

        }

        [HttpPost]
        public ActionResult CreateCategory(Entities.Category category)
        {

            System.Threading.Thread.Sleep(2000);

            if (ModelState.IsValid)
            {
                try
                {
                    new CategoryProcess().CreateCategory(category);
                }
                catch (Exception e)
                {
                  return   RedirectToRoute(ErrorControllerRoute.GetBadRequest,new{mensaje = e.Message});
                }

               
                var _lista = new Process.CategoryProcess().SelectList();
                return View("ListCategory", _lista);
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        //DoSomethingWith(error);
                    }
                }
            }

            return View();
        }


        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var _category = new CategoryProcess().GetById(id);

            return View(_category);



        }


        [HttpPost]
        public ActionResult DeleteCategory(Entities.Category category)
        {
            var _category = new CategoryProcess().RemoveCategory(category);

            var _lista = new Process.CategoryProcess().SelectList();
            return View("ListCategory", _lista);



        }




    }
}