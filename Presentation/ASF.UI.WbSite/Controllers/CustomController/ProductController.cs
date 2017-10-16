using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductController : Controller, IABMControlador<Product>
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

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(Product entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {

            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product entity)
        {

            try
            {
               
                //string pic = System.IO.Path.GetFileName(entity.Image);
                //string path = System.IO.Path.Combine(
                //    Server.MapPath("~/images/profile"), pic);
                //// file is uploaded
                //System.IO.File.Create(path);

                //// save the image path path to the database or you can send image 
                //// directly to database
                //// in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}


                var _dealerid = TempData["DealerId"];
                entity.Dealer = new Dealer()
                {
                    Id = (int)_dealerid
                };
                entity.CreatedBy = User.Identity.GetUserId();
                _processComponent.Create(entity);


                return RedirectToAction("Edit", "Dealer", new { id = User.Identity.GetUserId() });



            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

            }



        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Delete(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}