using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Cart : EntityBase
    {
        public Cart() {
			CartItem = new List<CartItem>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Cookie, no puede estar vacío")]
        [Length(Max=40, Message="La longitud del campo Cookie no debe ser mayor a 40 caracteres")]
        public virtual string Cookie { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Cart Date, no puede estar vacío")]
        public virtual DateTime CartDate { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Item Count, no puede estar vacío")]
        public virtual int ItemCount { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
        public virtual IList<CartItem> CartItem { get; set; }
    }
}
