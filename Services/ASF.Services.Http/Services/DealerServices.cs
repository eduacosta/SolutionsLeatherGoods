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

    [RoutePrefix("rest/Dealer")]
    [ExcepcionHttp]
    public class DealerServices : HtppBase<Dealer>
    {
        public override Dealer Add(Dealer entidad)
        {
          return  FachadaBLL.DealerBusiness.Add(entidad);
        }

        public override AllResponse<Dealer> All()
        {
            var _response = new AllResponse<Dealer>();
            _response.Result = FachadaBLL.DealerBusiness.All();
            return _response;

        }

        public override void Edit(Dealer entidad)
        {
            FachadaBLL.DealerBusiness.Edit(entidad);
        }

        public override FindResponse<Dealer> Find(int id)
        {
            var _response = new FindResponse<Dealer>();
            _response.Result = FachadaBLL.DealerBusiness.GetByID(new Dealer() {Id = id});

            return _response;


        }

        public override FindResponse<Dealer> Find(string id)
        {
            var _response = new FindResponse<Dealer>();
            _response.Result = FachadaBLL.DealerBusiness.GetByID(new Dealer() { AsPNetUsers = id });

            return _response;
        }

        public override void Remove(Dealer entidad)
        {
            FachadaBLL.DealerBusiness.Delete(entidad);
        }
    }
}
