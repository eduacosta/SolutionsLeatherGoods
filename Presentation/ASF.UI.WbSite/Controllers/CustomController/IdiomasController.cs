using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers.CustomController
{
    public class IdiomasController : Controller, IABMControlador<LocaleStringResource>
    {

        private IABMProcess<LocaleStringResource> _abmProcess;

        public IdiomasController()
        {

            this._abmProcess = new ProcessComponent<LocaleStringResource>();
        }


        [HttpGet]
        public JsonResult ListaIdiomas(string id)
        {

            try
            {

                var datos = _abmProcess.SelectList().Where(f => f.Language.LanguageCulture == id).ToDictionary(f => f.LocaleResourceKey.Name, g => g.ResourceValue);



                return Json(datos, JsonRequestBehavior.AllowGet);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }


        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(LocaleStringResource entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(LocaleStringResource entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(LocaleStringResource entity)
        {
            throw new NotImplementedException();
        }
    }
}