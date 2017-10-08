using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Controllers
{
    public class CountryController : Controller, IABMControlador<Country>
    {


        private ProcessComponent<Entities.Country> _countryprocess;

        public CountryController()
        {
            _countryprocess = new ProcessComponent<Entities.Country>();

        }

        // GET: Country
        public ActionResult Index()
        {
            try
            {
                var _datos = _countryprocess.SelectList();
                return View(_datos);
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

                var _datos = _countryprocess.GetById(int.Parse(id.ToString()));
                return View(_datos);

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }

        [HttpPost]
        public ActionResult Edit(Country entity)
        {
            try
            {
                entity.ChangedBy = User.Identity.GetUserId();
                _countryprocess.Edit(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country entity)
        {
            try
            {
                entity.CreatedBy = User.Identity.GetUserId();
                _countryprocess.Create(entity);            
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
                var _datos = _countryprocess.GetById(int.Parse(id.ToString()));
                return View(_datos);
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }

        [HttpPost]
        public ActionResult Delete(Country entity)
        {
            try
            {
                var _datos = _countryprocess.Remove(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }
    }
}