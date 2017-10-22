using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http.Services
{
    public class AñadirCarritoService : HtppBase<CartItem>
    {
        public override CartItem Add(CartItem entidad)
        {
          return  FachadaBLL.AñadirProductosAlCarrito.AñadirProductoAlCarrito(entidad);
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
