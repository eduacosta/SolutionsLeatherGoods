using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class OrderDetail : EntityBase
    {
        [DataMember]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Order, no puede estar vacío")]
        [DataMember]
        public virtual Order Order { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Product, no puede estar vacío")]
        [DataMember]
        public virtual Product Product { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Price, no puede estar vacío")]
        [DataMember]
        public virtual float Price { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Quantity, no puede estar vacío")]
        [DataMember]
        public virtual int Quantity { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        [DataMember]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        public virtual string ChangedBy { get; set; }
    }
}
