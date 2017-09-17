using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class CartItem : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public virtual int Id { get; set; }
        [DataMember]
        [DisplayName("Cart Id")]
        [NotNull(Message="Se debe cargar algún valor para el campo Cart, no puede estar vacío")]
        public virtual Cart Cart { get; set; }
        [DataMember]
        [DisplayName("Product Id")]
        [NotNull(Message="Se debe cargar algún valor para el campo Product Id, no puede estar vacío")]
        public virtual int ProductId { get; set; }
        [DataMember]
        [DisplayName("Price")]
        [NotNull(Message="Se debe cargar algún valor para el campo Price, no puede estar vacío")]
        public virtual float Price { get; set; }
        [DataMember]
        [DisplayName("Quantity")]
        [NotNull(Message="Se debe cargar algún valor para el campo Quantity, no puede estar vacío")]
        public virtual int Quantity { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        [DisplayName("Created On")]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        [DisplayName("Created By")]
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        [DataMember]
        [DisplayName("Changed On")]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        [DisplayName("Changed By")]
        public virtual int? ChangedBy { get; set; }
    }
}
