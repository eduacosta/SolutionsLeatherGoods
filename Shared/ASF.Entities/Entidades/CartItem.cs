using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class CartItem {
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Cart, no puede estar vacío")]
        public virtual Cart Cart { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Product Id, no puede estar vacío")]
        public virtual int ProductId { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Price, no puede estar vacío")]
        public virtual float Price { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Quantity, no puede estar vacío")]
        public virtual int Quantity { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
    }
}
