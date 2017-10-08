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
    public class ClienteController : Controller, IABMControlador<Client>
    {

        private Process.IABMProcess<Client> _abmProcess;
        public ClienteController()
        {
            _abmProcess = new ProcessComponent<Client>();
        }


        // GET: Cliente
        public ActionResult Index()
        {

            try
            {
                var _lista = _abmProcess.SelectList();
                return View(_lista);

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }

           
        }

        public ActionResult Edit(object id)
        {
            try
            {

                var cliente = _abmProcess.GetById(id.ToString());

                   
               //var categorias = new ProcessComponent<Country>()
               //    .SelectList().Select(c => new Country() { Id = c.Id, Name = c.Name })
               //    .ToList();



               // ViewBag.CategoryId = new SelectList(categorias, "Id", "Name");
                return View(cliente);



            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }
        }

        [HttpPost]
        public ActionResult Edit(Client entity)
        {
            try
            {
                entity.AspNetUsers = User.Identity.GetUserId();
                entity.Email = User.Identity.GetUserName();
                entity.Country = new Country(){Id = entity.CountryID};
                if (entity.AspNetUsers == null)
                {
                   
                    _abmProcess.Create(entity);
                    
                }
                else
                {
                    _abmProcess.Edit(entity);
                }

                return RedirectToAction("Edit", new {id = entity.AspNetUsers});
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }
        }

        [HttpPost]
        public ActionResult Edit(int Id,Client entity)
        {
            try
            {
                entity.AspNetUsers = User.Identity.GetUserId();
                entity.Email = User.Identity.GetUserName();
                entity.Country = new Country() { Id = entity.CountryID };
                if (entity.AspNetUsers == null)
                {

                    _abmProcess.Create(entity);

                }
                else
                {
                    _abmProcess.Edit(entity);
                }

                return RedirectToAction("Edit", new { id = entity.AspNetUsers });
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }
        }


        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(Client entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}