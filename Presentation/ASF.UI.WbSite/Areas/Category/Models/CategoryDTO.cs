using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ASF.UI.WbSite.Areas.Category.Models
{

    [JsonConverter(typeof(ToStringJsonConverter))]
    public class CategoryDTO
    {

       public string Name { get; set; }



        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }

    public class ToStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}