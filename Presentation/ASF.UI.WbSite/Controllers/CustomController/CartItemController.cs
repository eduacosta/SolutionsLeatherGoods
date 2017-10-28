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

    public class Producto
    {

        public int ProductId { get; set; }

        public float Precio { get; set; }

    }
   
    public class CartItemController : Controller, IABMControlador<CartItem>
    {

        private readonly IABMProcess<CartItem> _abmProcess;
        // GET: Carrito

        public CartItemController()
        {
            this._abmProcess = new ProcessComponent<CartItem>();

        }

        [HttpPost]
        public JsonResult Carrito(Producto producto)
        {
            try
            {
                string _cookievalue = null;
                 var cookie = Request.Cookies["Carritos"];
                if (cookie != null)
                {
                    _cookievalue = cookie.Value;
                }
                else
                {
                    lock (this)
                    {

               
                        var _cookie = new HttpCookie("Carritos");
                        _cookie.Value = Guid.NewGuid().ToString();
                        _cookie.Expires = DateTime.MaxValue;
                        _cookievalue = _cookie.Value;
                        Response.AppendCookie(_cookie);

                    }
                }
               

                var _cart = new Cart() {CartDate = DateTime.Now, Cookie = _cookievalue };
                _abmProcess.Create(new CartItem() {Cart = _cart, Price = producto.Precio, Product = new Product() {Id = producto.ProductId, Price = producto.Precio} });


                return Json("Producto Añadido Correctamente", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                

                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }



        }


       


        [HttpGet]
        public ActionResult CartItemXCookie()
        {

            try
            {
                string _cookievalue = null;
                var cookie = Request.Cookies["Carritos"];
                if (cookie != null)
                {
                    _cookievalue = cookie.Value;
                }
                var _cartitem = _abmProcess.SelectList("rest/CartItem/ListaCarritoXCookie", _cookievalue).ToList();
                return View(_cartitem.ToArray());


            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

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

        [HttpGet]
        public JsonResult Eliminar(object id)
        {
            try
            {



                _abmProcess.Remove(new CartItem() { Id = int.Parse(id.ToString()) });
                return Json("Producto eliminado Correctamente", JsonRequestBehavior.AllowGet);

               


            }
            catch (Exception ex)
            {


                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Delete(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}