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
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Category> SelectList()
        {
            var response = HttpGet<AllResponse<Category>>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Category EditCategory(Category category)
        {

            var reponse = HttpPost("rest/Category/Edit", category, mediaType: MediaType.Json);

            return reponse;

        }

        public Category GetById(int id)
        {

            var reponse = HttpGet<FindResponse<Category>>("rest/Category/Find", new Dictionary<string, object>() { { "id", id } },
                mediaType: MediaType.Json);
            return reponse.Result;

        }


        public Category RemoveCategory(Category category)
        {

            var response = HttpPost("rest/Category/Remove", category, MediaType.Json);
            return response;

        }

        public Category CreateCategory(Category category)
        {
            try
            {



                var response = HttpPost("rest/Category/Add", category, MediaType.Json);
                return response;

            }
            catch( Exception ex )
            {

                throw;
            }

        }

    }
}