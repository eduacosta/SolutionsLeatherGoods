using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants.CategoryController;

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

       
        public ActionResult EditCategory(int id)
        {
            var _category = new CategoryProcess().GetById(id);
            return View(_category);


        }


    }
}