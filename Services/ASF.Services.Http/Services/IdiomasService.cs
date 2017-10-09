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

    [RoutePrefix("rest/LocaleStringResource")]
     public class IdiomasService : ApiController
    {

        [HttpGet]
        [Route("All")]
        public AllResponse<LocaleStringResource> ListaLenguajes()
        {

           var _datos = new AllResponse<LocaleStringResource>();
            _datos.Result = FachadaBLL.LanguajeBusiness.GetLenguajesResourceByLanguaje().ToList();
            return _datos;

        }

    }
}
