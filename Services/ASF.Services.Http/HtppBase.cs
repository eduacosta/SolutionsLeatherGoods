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

namespace ASF.Services.Http
{
    public abstract class HtppBase <T> where T : EntityBase
    {

        [HttpPost]
        [Route("Add")]
        public abstract T Add(T entidad);


        [HttpGet]
        [Route("All")]
        public abstract AllResponse All();


        [HttpPost]
        [Route("Edit")]
        public abstract void Edit(Category category);
       

        [HttpGet]
        [Route("Find")]
        public abstract FindResponse Find(int id)
       

        [HttpPost]
        [Route("Remove")]
        public void Remove(Category category)
        {
            try
            {
                var bc = FachadaBLL.CategoryBusiness;
                bc.Delete(new Category() { Id = category.Id });
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

    }
}
