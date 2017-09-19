using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Client.Controllers
{
    public class ClientController : Controller, IABMControlador<Entities.Client>
    {

        private ProcessComponent<Entities.Client> _categoyprocess;

        public ClientController()
        {
            _categoyprocess = new ProcessComponent<Entities.Client>();

        }


        public ActionResult ListEntity()
        {
            var _lista = _categoyprocess.SelectList();
            return View(_lista);
        }

        public ActionResult EditEntity(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult EditEntity(Entities.Client entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateEntity()
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateEntity(Entities.Client entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteEntity(Entities.Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
