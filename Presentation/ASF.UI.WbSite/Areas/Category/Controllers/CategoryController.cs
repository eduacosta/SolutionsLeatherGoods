using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category/Category
        public ActionResult ListaCategory()
        {


            var _lista = new Process.CategoryProcess().SelectList();
            return View(_lista);
        }

       
        public ActionResult EditCategory(int id)
        {
            var _category = new CategoryProcess().GetById(id);
            return View(_category);


        }


    }
}