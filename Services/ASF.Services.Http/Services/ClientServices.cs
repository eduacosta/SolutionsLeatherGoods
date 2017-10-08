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
using Bitacora.Excepciones;

namespace ASF.Services.Http.Services
{
    [RoutePrefix("rest/Client")]
    [ExcepcionHttp]
    public  class ClientServices : HtppBase<Entities.Client>
    {
        public override Client Add(Client entidad)
        {
            //try
            //{
                var bc = FachadaBLL.ClentBusiness;
                return bc.Add(entidad);
            //}
            //catch (Exception ex)
            //{
            //    var httpError = new HttpResponseMessage()
            //    {
            //        StatusCode = (HttpStatusCode)422,
            //        ReasonPhrase = ex.Message
            //    };

            //    throw new HttpResponseException(httpError);
            //}
        }

        public override AllResponse<Client> All()
        {
            //try
            //{

                var bc = FachadaBLL.ClentBusiness;
                base.AllResult.Result = bc.All();
                return base.AllResult;
            //}
            //catch (Exception ex)
            //{
            //    var httpError = new HttpResponseMessage()
            //    {
            //        StatusCode = (HttpStatusCode)422,
            //        ReasonPhrase = ex.Message
            //    };

            //    throw new HttpResponseException(httpError);
            //}
        }

        public override void Edit(Client entidad)
        {
            //try
            //{
                var bc = FachadaBLL.ClentBusiness;
                bc.Edit(entidad);
            //}
            //catch (Exception ex)
            //{
            //    var httpError = new HttpResponseMessage()
            //    {
            //        StatusCode = (HttpStatusCode)422,
            //        ReasonPhrase = ex.Message
            //    };

            //    throw new HttpResponseException(httpError);
            //}
        }

        public override FindResponse<Client> Find(string id)
        {
            //try
            //{

                var bc = FachadaBLL.ClentBusiness;
                base.FindResult.Result = bc.GetByID(new Client() { AspNetUsers = id.ToString() });
                return base.FindResult;
            //}
            //catch (Exception ex)
            //{
            //    var httpError = new HttpResponseMessage()
            //    {
            //        StatusCode = (HttpStatusCode)422,
            //        ReasonPhrase = ex.Message
            //    };

            //    throw new HttpResponseException(httpError);
            //}
        }

        public override FindResponse<Client> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Client entidad)
        {
            //try
            //{
                var bc = FachadaBLL.ClentBusiness;
                bc.Delete(new Client() { Id = entidad.Id });
            //}
            //catch (Exception ex)
            //{
            //    var httpError = new HttpResponseMessage()
            //    {
            //        StatusCode = (HttpStatusCode)422,
            //        ReasonPhrase = ex.Message
            //    };

            //    throw new HttpResponseException(httpError);
            //}
        }
    }
}
