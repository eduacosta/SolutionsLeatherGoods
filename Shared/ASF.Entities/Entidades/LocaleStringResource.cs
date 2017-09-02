using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class LocaleStringResource : EntityBase
    {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Locale Resource Key, no puede estar vací" +
            "o")]
        public virtual LocaleResourceKey LocaleResourceKey { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Language, no puede estar vacío")]
        public virtual Language Language { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Resource Value, no puede estar vacío")]
        [Length(Max=1000, Message="La longitud del campo Resource Value no debe ser mayor a 1000 caracteres")]
        public virtual string ResourceValue { get; set; }
    }
}
