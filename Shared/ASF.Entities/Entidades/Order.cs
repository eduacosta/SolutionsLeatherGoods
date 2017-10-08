using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Order : EntityBase
    {
        public Order() {
			OrderDetail = new List<OrderDetail>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Client, no puede estar vacío")]
        public virtual Client Client { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Order Date, no puede estar vacío")]
        public virtual DateTime OrderDate { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Total Price, no puede estar vacío")]
        public virtual float TotalPrice { get; set; }
        public virtual int? State { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Order Number, no puede estar vacío")]
        public virtual int OrderNumber { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Item Count, no puede estar vacío")]
        public virtual int ItemCount { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual IList<OrderDetail> OrderDetail { get; set; }
    }
}
