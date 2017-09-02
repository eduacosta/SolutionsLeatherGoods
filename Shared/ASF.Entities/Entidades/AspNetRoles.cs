using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {

    [Serializable]
    [DataContract]
    public class AspNetRoles : EntityBase {
        public AspNetRoles() {
			AspNetUserRoles = new List<AspNetUserRoles>();
        }
        public virtual string Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=256, Message="La longitud del campo Name no debe ser mayor a 256 caracteres")]
        public virtual string Name { get; set; }
        public virtual IList<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
