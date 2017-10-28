using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using ASF.Entities.DTO;
using ASF.Services.Contracts;

namespace ASF.Services.Http.Services
{

    [RoutePrefix("rest/ConfirmarCompra")]
    public class ConfirmarCompraService : HtppBase<OrderDetail>
    {

        [Route("AddList")]
        [HttpPost]
        public void AddList(CartItemDTO cartItemDto)
        {
            
            FachadaBLL.ConfirmarCompra.ConfirmarCompra(cartItemDto);

        }

        public override OrderDetail Add(OrderDetail entidad)
        {
            throw new NotImplementedException();
        }

        public override AllResponse<OrderDetail> All()
        {
            throw new NotImplementedException();
        }

        public override void Edit(OrderDetail entidad)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<OrderDetail> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<OrderDetail> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(OrderDetail entidad)
        {
            throw new NotImplementedException();
        }
    }
}
