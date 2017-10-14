using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using ASF.Services.Contracts;
using Bitacora.Excepciones;

namespace ASF.Services.Http.Services
{
    
    [RoutePrefix("rest/Product")]
    [ExcepcionHttp]
    public class ProductService : HtppBase<Product>
    {

        [HttpGet]
        [Route("ProductXDealer")]
        public AllResponse<Product> ProductosXDealer(int id)
        {
            var _response = new AllResponse<Product>();
            _response.Result = FachadaBLL.ProductBusiness.ListaProductosXDealer(new Dealer(){Id = id});
            return _response;

        }

        public override Product Add(Product entidad)
        {
            throw new NotImplementedException();
        }

        public override AllResponse<Product> All()
        {
            throw new NotImplementedException();
        }

        public override void Edit(Product entidad)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Product> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Product> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Product entidad)
        {
            throw new NotImplementedException();
        }
    }
}
