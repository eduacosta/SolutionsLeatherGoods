using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Error : EntityBase
    {
        public virtual int Id { get; set; }
        public virtual int? ClientId { get; set; }
        public virtual DateTime? ErrorDate { get; set; }
        [Length(Max=40, Message="La longitud del campo Ip Address no debe ser mayor a 40 caracteres")]
        public virtual string IpAddress { get; set; }
        public virtual string ClientAgent { get; set; }
        public virtual string Exception { get; set; }
        public virtual string Message { get; set; }
        public virtual string Everything { get; set; }
        [Length(Max=500, Message="La longitud del campo Http Referer no debe ser mayor a 500 caracteres")]
        public virtual string HttpReferer { get; set; }
        [Length(Max=500, Message="La longitud del campo Path And Query no debe ser mayor a 500 caracteres")]
        public virtual string PathAndQuery { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
    }
}
