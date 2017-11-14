using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Routing;
using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants.CarritoCompra;
using ASF.UI.WbSite.Models.CustomModel;
using ASF.UI.WbSite.Services.Cache;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Controllers
{

    public class Producto
    {

        public int ProductId { get; set; }

        public float Precio { get; set; }


    }

    

    public class PagoConTarjeta
    {
        public string holder_name { get; set; }
        public string address { get; set; }
        public int number { get; set; }
        public int exp_year { get; set; }
        public int exp_month { get; set; }

        public int cvc { get; set; }

        public int Id { get; set; }
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
        public ActionResult Carrito(Producto pro)
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
                _abmProcess.Create(new CartItem() {Cart = _cart, Price = pro.Precio, Product = new Product() {Id = pro.ProductId, Price = pro.Precio} });
                Json(HttpStatusCode.OK, "You are not authorised to view this.");
                
                //return Json("Producto Añadido Correctamente", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);

            }



        }


       


        [HttpGet]
        public ActionResult CartItemXCookie()
        {

            try
            {
                string _cookievalue = null;
                var cookie = Request.Cookies["Carritos"];
                ViewModelCarItem_Order _modelCarItemOrder = new ViewModelCarItem_Order();
                if (cookie != null)
                {
                    _cookievalue = cookie.Value;

                    var _cartitem = _abmProcess.SelectList("rest/CartItem/ListaCarritoXCookie", _cookievalue).ToList();

                    
                    _modelCarItemOrder.CartItems = _cartitem.ToArray();
                }
               


                if (User.Identity.IsAuthenticated)
                {
                   
                    var _orderlist = new ProcessComponent<Order>().SelectList("rest/Order/AllXCliente", User.Identity.GetUserId()).ToList();
                    _modelCarItemOrder.Order = _orderlist.ToArray();

                }



                return View(_modelCarItemOrder);


            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }


        }


        [HttpPost]
        public JsonResult PagarCompra(PagoConTarjeta pagarcontarjeta)

        {
            try
            {
                Thread.Sleep(2000);

                Order _order = new Order();
                _order.Id = pagarcontarjeta.Id;
                _order.State = Status.Approved;
                
                new ProcessComponent<Order>().Edit( _order);
                return Json("Producto pagado Correctamente", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {


                return Json(ex.Message, JsonRequestBehavior.AllowGet);

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