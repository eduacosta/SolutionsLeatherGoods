using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Controllers.CustomController
{
    public class LanguajeController : Controller, IABMControlador<Language>
    {

        private IABMProcess<Language> _abmProcess;


        public LanguajeController()
        {
            

            this._abmProcess = new ProcessComponent<Language>();
        }

        [HttpGet]
        public JsonResult ListaLenguajes()
        {

            try
            {

                var _datos = _abmProcess.SelectList("rest/Languaje/All", null).ToList();
                return  Json(_datos, JsonRequestBehavior.AllowGet );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        // GET: Languaje
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(Language entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(Language entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Language entity)
        {
            throw new NotImplementedException();
        }
    }
}