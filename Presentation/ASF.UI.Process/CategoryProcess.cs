using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CategoryProcess : ProcessComponent, IABMProcess<Category>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Category> SelectList()
        {
          

            return CallHttpGetAll<Category>();

        }

        public Category EditCategory(Category entity)
        {

            //var reponse = HttpPost("rest/Category/Edit", entity, mediaType: MediaType.Json);
            //return reponse;

            return CallHttpPostEdit(entity);
        }

        public Category GetById(int id)
        {

            //var reponse = HttpGet<FindResponse<Category>>("rest/Category/Find", new Dictionary<string, object>() { { "id", id } },
            //    mediaType: MediaType.Json);
            //return reponse.Result;

            return CallHttpGetById<Category>(new Dictionary<string, object>() { { "id", id }});

        }


        public Category RemoveCategory(Category entity)
        {

            //var response = HttpPost("rest/Category/Remove", entity, MediaType.Json);
            //return response;

            return CallHttpPostRemove(entity);

        }

        public Category CreateCategory(Category entity)
        {
            try
            {


                //var response = HttpPost("rest/Category/Add", entity, MediaType.Json);
                //return response;

                return CallHttpPostAdd(entity);

            }
            catch( Exception ex )
            {

                throw;
            }

        }

    }
}