using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Routing;
using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants.CarritoCompra;
using ASF.UI.WbSite.Models.CustomModel;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Controllers
{
   
    public class CartItemController : Controller, IABMControlador<CartItem>
    {

        private readonly IABMProcess<CartItem> _abmProcess;
        // GET: Carrito

        public CartItemController()
        {
            this._abmProcess = new ProcessComponent<CartItem>();

        }

        [HttpGet]
        public ActionResult Carrito(int ProductId)
        {
            try
            {
                string _cookievalue = null;
                 var cookie = Request.Cookies["Carrito"];
                if (cookie != null)
                {
                    _cookievalue = cookie.Value;
                }
                else
                {
                    var _cookie = new HttpCookie("Carrito");
                    _cookie.Value = DateTime.Now.ToString();
                    _cookievalue = _cookie.Value;
                    Response.AppendCookie(_cookie);
                }
               

                var _cart = new Cart() {CartDate = DateTime.Now, Cookie = _cookievalue };
                _abmProcess.Create(new CartItem() {Cart = _cart , Product = new Product() {Id = ProductId} });

                
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new
                {
                    mensaje = ex.Message
                });

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

        public ActionResult Edit(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}