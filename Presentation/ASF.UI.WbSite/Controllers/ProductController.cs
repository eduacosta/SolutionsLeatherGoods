using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductController : Controller
    {

        private ProcessComponent<Product> _processComponent;
        public ProductController()
        {
            this._processComponent = new ProcessComponent<Product>();

        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
    }
}