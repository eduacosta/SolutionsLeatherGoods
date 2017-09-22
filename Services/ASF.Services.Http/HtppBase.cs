using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using ASF.Services.Contracts;
//using ASF.Services.Contracts.Responses;

namespace ASF.Services.Http
{
    public abstract class HtppBase<T> : ApiController where T : EntityBase
    {
        private AllResponse<T> _Allresonpse = new AllResponse<T>();

        public AllResponse<T> AllResult
        {
            get { return _Allresonpse; }
            set { _Allresonpse = value; }
        }

        private FindResponse<T> _FindResponse = new FindResponse<T>();
        public FindResponse<T> FindResult
        {
            get { return _FindResponse; }
            set { _FindResponse = value; }
        }


        [HttpPost]
        [Route("Add")]
        public abstract T Add(T entidad);


        [HttpGet]
        [Route("All")]
        public abstract AllResponse<T> All();


        [HttpPost]
        [Route("Edit")]
        public abstract void Edit(T entidad);


        [HttpGet]
        [Route("Find")]
        public abstract  FindResponse<T> Find(int id);


        [HttpPost]
        [Route("Remove")]
        public abstract void Remove(T entidad);


        [HttpGet]
        [Route("Idiomas")]
        public IDictionary<LocaleResourceKey, string> ListaLenguajes(int id)
        {

            var language = new Language(){Id = id};
            return FachadaBLL.LanguajeBusiness.GetLenguajesResourceByLanguaje(language);


        }


    }
}
