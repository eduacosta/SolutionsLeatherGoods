using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.Entities.DTO;
using ASF.UI.Process;
using Microsoft.AspNet.Identity;

namespace ASF.UI.WbSite.Controllers.CustomController
{
    public class OrderDetailController : Controller
    {

        public IABMProcess<OrderDetail> _AbmProcess;


        public OrderDetailController()
        {
            
            this._AbmProcess = new ProcessComponent<OrderDetail>();
        }

        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult FinalizarCompra(CartItem[] carttime)
        {


            try
            {

                IList<CartItem> _cartItems = carttime.ToList();
                CartItemDTO _cartItemDto = new CartItemDTO()
                {
                    ListaCartItem = _cartItems,
                    Client = new Client()
                    {
                        AspNetUsers = User.Identity.GetUserId()
                    }

                };
                _AbmProcess.AddCustom("rest/ConfirmarCompra/AddList", _cartItemDto);

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }

    }
}