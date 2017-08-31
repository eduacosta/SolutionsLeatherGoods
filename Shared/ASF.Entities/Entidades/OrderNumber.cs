using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class OrderNumber {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Number, no puede estar vacío")]
        public virtual int Number { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
    }
}
