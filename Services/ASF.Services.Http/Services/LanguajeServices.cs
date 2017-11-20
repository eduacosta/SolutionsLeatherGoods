using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Business.FachadaBLL;
using ASF.Business.IABM;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http.Services
{

    [RoutePrefix("rest/Languaje")]
   
    public class LanguajeServices : HtppBase<Language>
    {
        public override Language Add(Language entidad)
        {
            throw new NotImplementedException();
        }

        public override AllResponse<Language> All()
        {
            var _response = new AllResponse<Language>();

            _response.Result = FachadaBLL.LenguajeBusiness.ListaLenguajes();

            return _response;

        }

        public override void Edit(Language entidad)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Language> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override FindResponse<Language> Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Language entidad)
        {
            throw new NotImplementedException();
        }
    }
}
