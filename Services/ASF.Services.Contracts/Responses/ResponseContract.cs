using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class ResponseContract <T> where T : EntityBase
    {
        [DataMember]
        public IList<T> AllResult { get; set; }

        [DataMember]
        public T FindResult { get; set; }


    }
}
