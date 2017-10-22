using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ASF.Entities;

namespace ASF.Business.Patrones.TMCart
{
    public abstract class ITMAñadirAlCarrito
    {

        protected abstract Cart AñadirCarrito(Cart cart);

        protected abstract CartItem AñadirDetalleCarrito(CartItem cariItem);


        public  void AñadirProductoAlCarrito(CartItem cartItem)
        {

            using (var tran = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                var _cart = AñadirCarrito(cartItem.Cart);
                cartItem.Cart = _cart;
                var _cartitem = AñadirDetalleCarrito(cartItem);

                tran.Complete();

                

            }



        }



    }
}
