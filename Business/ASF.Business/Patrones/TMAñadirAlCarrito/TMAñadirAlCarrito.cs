using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.Patrones.TMCart;
using ASF.Entities;

namespace ASF.Business.Patrones.TMAñadirAlCarrito
{
    class TMAñadirAlCarrito : ITMAñadirAlCarrito
    {
        protected override Cart AñadirCarrito(Cart cart)
        {
            return FachadaBLL.FachadaBLL.CartBusiness.Add(cart);
        }

        protected override CartItem AñadirDetalleCarrito(CartItem cariItem)
        {
            return FachadaBLL.FachadaBLL.CartItemBusiness.Add(cariItem);
        }
    }
}
