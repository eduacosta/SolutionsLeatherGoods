using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities
{
    [Serializable]
    [DataContract]
    public class Order : EntityBase
    {
        public Order()
        {
            OrderDetail = new List<OrderDetail>();
        }
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        [NotNull(Message = "Se debe cargar algún valor para el campo Client, no puede estar vacío")]
        public virtual Client Client { get; set; }
        [NotNull(Message = "Se debe cargar algún valor para el campo Order Date, no puede estar vacío")]
        [DataMember]
        public virtual DateTime OrderDate { get; set; }

        [NotNull(Message = "Se debe cargar algún valor para el campo Total Price, no puede estar vacío")]
        [DataMember]
        public virtual float TotalPrice { get; set; }
        [DataMember]
        public virtual Status State { get; set; }
        [NotNull(Message = "Se debe cargar algún valor para el campo Order Number, no puede estar vacío")]
        [DataMember]
        public virtual int OrderNumber { get; set; }
        [NotNull(Message = "Se debe cargar algún valor para el campo Item Count, no puede estar vacío")]
        [DataMember]
        public virtual int ItemCount { get; set; }
        [DataMember]
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message = "Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        public virtual string CreatedBy { get; set; }
        [NotNull(Message = "Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        [DataMember]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        public virtual string ChangedBy { get; set; }
        [DataMember]
        public virtual IList<OrderDetail> OrderDetail { get; set; }
    }

   
    public enum Status
    {
        Reviewed,
        Suspended,
        Closed,
        Cancelled,
        Approved

    }

}
