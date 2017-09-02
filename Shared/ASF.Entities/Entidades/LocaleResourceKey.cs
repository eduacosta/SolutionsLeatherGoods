using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class LocaleResourceKey : EntityBase
    {
        public LocaleResourceKey() {
			LocaleStringResource = new List<LocaleStringResource>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=200, Message="La longitud del campo Name no debe ser mayor a 200 caracteres")]
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Date Added, no puede estar vacío")]
        public virtual DateTime DateAdded { get; set; }
        public virtual IList<LocaleStringResource> LocaleStringResource { get; set; }
    }
}
