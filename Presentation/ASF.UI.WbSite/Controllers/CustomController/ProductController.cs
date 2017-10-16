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
            try
            {
                int _id = int.Parse(id.ToString());
                var _datos = _processComponent.GetById(_id);

                return View(_datos);

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


            throw new NotImplementedException();


        }


        [HttpPost]
        public ActionResult CreateFile(Product entity, HttpPostedFileBase file)
        {

            try
            {


                entity.Image = ConvertToBytes(file);
                           
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


        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

       
    }
}