using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class AspNetUserClaims {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Users, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Users no debe ser mayor a 128 caracteres")]
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
    }
}
