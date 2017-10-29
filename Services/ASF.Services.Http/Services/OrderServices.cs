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
    [RoutePrefix("rest/Order")]
    public class OrderServices : HtppBase<Order>
    {
        public override Order Add(Order entidad)
        {
            throw new NotImplementedException();
        }

        public override AllResponse<Order> All()
        {
            throw new NotImplementedException();

        }
        
        [HttpGet]
        [Route("AllXCliente")]
        public  AllResponse<Order> AllXCliente(string id)
        {

            Client _client = new Client() { AspNetUsers = id };
            AllResponse<Order> _allResponse = new AllResponse<Order>();

            _allResponse.Result = FachadaBLL.OrderBusiness.OrdernesXCliente(_client);


            return _allResponse;

        }

        public override void Edit(Order entidad)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Order> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Order> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Order entidad)
        {
            throw new NotImplementedException();
        }
    }
}
