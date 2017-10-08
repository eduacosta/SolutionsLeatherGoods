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
   [RoutePrefix("rest/Country")]
   [ExcepcionHttp]
    public  class CountryService : HtppBase<Country>
    {
        public override Country Add(Country entidad)
        {
           return FachadaBLL.CountryBusiness.Add(entidad);
        }

        public override AllResponse<Country> All()
        {

            var lista = new AllResponse<Country>();
            lista.Result =  FachadaBLL.CountryBusiness.All();
            return lista;
        }

        public override void Edit(Country entidad)
        {
            FachadaBLL.CountryBusiness.Edit(entidad);
        }

        public override FindResponse<Country> Find(int id)
        {
            var lista = new FindResponse<Country>();
            lista.Result = FachadaBLL.CountryBusiness.GetByID(new Country(){Id =  int.Parse( id.ToString())});
            return lista;
        }

        public override FindResponse<Country> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Country entidad)
        {
           FachadaBLL.CountryBusiness.Delete(entidad);
        }
    }
}
