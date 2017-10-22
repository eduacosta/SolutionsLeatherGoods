using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http.Services
{

    [RoutePrefix("rest/CartItem")]
    public class CartItemService : HtppBase<CartItem>
    {
        public override CartItem Add(CartItem entidad)
        {
            FachadaBLL.AñadirProductosAlCarrito.AñadirProductoAlCarrito(entidad);

            return new CartItem();
        }

        public override AllResponse<CartItem> All()
        {
            throw new NotImplementedException();
        }

        public override void Edit(CartItem entidad)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<CartItem> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<CartItem> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(CartItem entidad)
        {
            throw new NotImplementedException();
        }
    }
}
