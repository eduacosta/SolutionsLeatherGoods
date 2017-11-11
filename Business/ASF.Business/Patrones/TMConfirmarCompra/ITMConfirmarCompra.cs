using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ASF.Entities;
using ASF.Entities.DTO;
using NHibernate.Util;

namespace ASF.Business.Patrones.TMConfirmarCompra
{
    public abstract class ITMConfirmarCompra
    {

        protected abstract OrderNumber GenerarOrderNumber();

        protected abstract Order GenerarOrden(Order order);


        protected abstract void GenerarOrderDetails(IList<OrderDetail> orderDetails);

        protected abstract Client ClientXAspUser(Client client);

        public Order ConfirmarCompra(CartItemDTO cartItemsdto)
        {
            using (var _tran = new TransactionScope())
            {
                OrderNumber _orderNumber = GenerarOrderNumber();
                int  _clientid = ClientXAspUser(new Client() {AspNetUsers = cartItemsdto.Client.AspNetUsers}).Id;
                Order _order = GenerarOrden(new Order()
                {
                    OrderNumber = _orderNumber.Number,
                    Client = new Client(){Id = _clientid },
                    ItemCount = cartItemsdto.ListaCartItem.Count,
                    TotalPrice = (cartItemsdto.ListaCartItem.Sum(g => g.Quantity) * cartItemsdto.ListaCartItem.Sum(f => f.Product.Price)),
                    OrderDate = DateTime.Now,
                    State  = Status.Reviewed,
                    CreatedBy = cartItemsdto.Client.AspNetUsers,
                    CreatedOn = DateTime.Now

                });


                var _orderdetails = cartItemsdto.ListaCartItem.Select(c => new OrderDetail()
                {
                    Product = c.Product,
                    Price = c.Product.Price,
                    Order = _order,
                    Quantity = c.Quantity


                }).ToList();

              

                GenerarOrderDetails(_orderdetails);

                _tran.Complete();
                return _order;

            }





        }






    }
}
