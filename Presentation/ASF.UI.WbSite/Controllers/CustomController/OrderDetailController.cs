using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.Entities.DTO;
using ASF.UI.Process;
using ASF.UI.WbSite.Models.CustomModel;
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
        public ActionResult FinalizarCompra(ViewModelCarItem_Order carttime)
        {


            try
            {

                IList<CartItem> _cartItems = carttime.CartItems.ToList();
                CartItemDTO _cartItemDto = new CartItemDTO()
                {
                    ListaCartItem = _cartItems,
                    Client = new Client()
                    {
                        AspNetUsers = User.Identity.GetUserId()
                    }

                };
                 _AbmProcess.AddCustom("rest/ConfirmarCompra/AddList", _cartItemDto);

                return RedirectToAction("CartItemXCookie","CartItem");
            }
            catch (Exception ex)
            {
                return RedirectToAction("badrequest", "Error", new { mensaje = ex.Message });

            }
        }

    }
}