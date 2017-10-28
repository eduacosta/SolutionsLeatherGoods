using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.UI.Process
{
    /// <summary>
    /// Base class for UI Controllers (not the ASP.NET MVC Controllers).
    /// This class is purposely renamed to ProcessComponent to avoid confusion from the MVC controllers.
    /// </summary>
    public  class ProcessComponent<T> : IABMProcess<T> where T : EntityBase
    {
        /// <summary>
        /// Sends a Http Get request to a URL with querystring style parameters.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="path">The path to the service.</param>
        /// <param name="parameters">A dictionary containing the parameters and values to form the query.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        private static T HttpGet<T>(string path, Dictionary<string, object> parameters, string mediaType)
        {
            UriBuilder builder = new UriBuilder
            {
                Path = path,
                Query = string.Join("&", parameters.Where(p => p.Value != null)
                    .Select(p => string.Format("{0}={1}",
                        HttpUtility.UrlEncode(p.Key),
                        HttpUtility.UrlEncode(p.Value.ToString()))))
            };

            return HttpGet<T>(builder.Uri.PathAndQuery, mediaType);
        }

        /// <summary>
        /// Sends a Http Get request to a URL with parameters separated by /.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="path">The path to the service.</param>
        /// <param name="values">A list of parameter values to form the query.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <return
        private static T HttpGet<T>(string path, List<object> values, string mediaType)
        {
            string query = string.Empty;
            string pathAndQuery = path.EndsWith("/") ? path : path += "/";

            if (values != null && values.Count > 0)
                query = string.Join("/", values.ToArray());

            if (!string.IsNullOrWhiteSpace(query))
                pathAndQuery += query;

            return HttpGet<T>(pathAndQuery, mediaType);
        }

        /// <summary>
        /// Sends a Http Get request to a URL.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="pathAndQuery">The path and query to call.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        private static T HttpGet<T>(string pathAndQuery, string mediaType)
        {
            T result = default(T);

            // Execute the Http call.
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                var response = client.GetAsync(pathAndQuery).Result;
                response.EnsureSuccessStatusCode();

                result = response.Content.ReadAsAsync<T>().Result;
            }

            return result;
        }

        private static T HttpPost<T>(string path, T value, string mediaType)
        {

            try
            {




                var pathAndQuery = path.EndsWith("/") ? path : path + "/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                    var response = client.PostAsJsonAsync(pathAndQuery, value).Result;
                    response.EnsureSuccessStatusCode();
                    return value;

                }
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                throw;
            }

        }

        private static  IList<T> CallHttpGetAll<T>(string Url = null,Dictionary < string, object> parametros = null) where  T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var response = HttpGet<AllResponse<T>>(Url ?? $"rest/{nombreclase}/All", parametros ?? new Dictionary<string, object>(), MediaType.Json);
            return response.Result;

        }


        private static T CallHttpGetById<T>(Dictionary<string, object> parametros = null) where T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var reponse = HttpGet<FindResponse<T>>($"rest/{nombreclase}/Find", parametros ?? new Dictionary<string, object>(),
                mediaType: MediaType.Json);
            return reponse.Result;
        }


        private static T CallHttpGetByIdString<T>(Dictionary<string, object> parametros = null) where T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var reponse = HttpGet<FindResponse<T>>($"rest/{nombreclase}/FindString", parametros ?? new Dictionary<string, object>(),
                mediaType: MediaType.Json);
            return reponse.Result;
        }


        private static T CallHttpPostRemove<T>(T value) where T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var response = HttpPost($"rest/{nombreclase}/Remove", value, MediaType.Json);
            return response;
        }

        private static T CallHttpPostEdit<T>(T value) where T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var response = HttpPost($"rest/{nombreclase}/Edit", value, MediaType.Json);
            return response;
        }

        private static T CallHttpPostAdd<T>(T value) where T : EntityBase
        {
            var nombreclase = typeof(T).Name;
            var response = HttpPost($"rest/{nombreclase}/Add", value, MediaType.Json);
            return response;
        }

        private static void CallHttpPostAdd(string url ,object value) 
        {
           
             HttpPost(url, value, MediaType.Json);
           
        }

        public void AddCustom(string URL, object objeto)
        {
             CallHttpPostAdd(URL, objeto);
        
        }


        public IList<T> SelectList()
        {
            return CallHttpGetAll<T>();
        }

        public IList<T> SelectList(string URL, string id)
        {
            return CallHttpGetAll<T>(URL, new Dictionary<string, object>(){{"id", id}});
        }

        public IList<T> SelectList(string URL, int id)
        {
            return CallHttpGetAll<T>(URL, new Dictionary<string, object>() { { "id", id } });
        }

        public T Edit(T entity)
        {
            return CallHttpPostEdit(entity);
        }

        public T GetById(int id)
        {
            //var f = id.GetType();

            //var ob = Activator.CreateInstance(f);

            //ob = id;

            return CallHttpGetById<T>(new Dictionary<string, object>() { { "id", id } });
        }

        public T GetById(string id)
        {
            return CallHttpGetByIdString<T>(new Dictionary<string, object>() { { "id", id } });
        }

        public T Remove(T entity)
        {
            return CallHttpPostRemove(entity);
        }

        public T Create(T entity)
        {
            return CallHttpPostAdd(entity);
        }


      
    }
}
