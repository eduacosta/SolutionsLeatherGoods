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

//using ASF.Services.Contracts.Responses;

namespace ASF.Services.Http.Services
{
    [RoutePrefix("rest/Category")]
    [ExcepcionHttp]
    public  class CategoryService : HtppBase<Entities.Category>
    {
        public override Entities.Category Add(Entities.Category entidad)
        {

            //try
            //{
                var bc = FachadaBLL.CategoryBusiness;
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

        public override AllResponse<Entities.Category> All()
        {
            //try
            //{
                
                var bc = FachadaBLL.CategoryBusiness;
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

        public override void Edit(Entities.Category entidad)
        {
            //try
            //{
                var bc = FachadaBLL.CategoryBusiness;
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

        public override FindResponse<Category> Find(int id)
        {
            //try
            //{
                
                var bc = FachadaBLL.CategoryBusiness;
                base.FindResult.Result = bc.GetByID(new Category() { Id = id });
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

        public override void Remove(Entities.Category entidad)
        {
            //try
            //{
                var bc = FachadaBLL.CategoryBusiness;
                bc.Delete(new Category() { Id = entidad.Id });
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
