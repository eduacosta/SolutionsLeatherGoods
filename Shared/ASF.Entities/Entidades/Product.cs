using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Product : EntityBase
    {
        public Product() {
			OrderDetail = new List<OrderDetail>();
			Rating = new List<Rating>();
        }

        [DataMember]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Dealer, no puede estar vacío")]
        [DataMember]
        public virtual Dealer Dealer { get; set; }
        [DataMember]
        [NotNull(Message="Se debe cargar algún valor para el campo Title, no puede estar vacío")]
        [Length(Max=100, Message="La longitud del campo Title no debe ser mayor a 100 caracteres")]

        public virtual string Title { get; set; }
        [Length(Max=250, Message="La longitud del campo Description no debe ser mayor a 250 caracteres")]
        [DataMember]
        public virtual string Description { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Image, no puede estar vacío")]

        [DataMember]
        public virtual byte[] Image { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Price, no puede estar vacío")]
        [DataMember]
        public virtual float Price { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Quantity Sold, no puede estar vacío")]
        [DataMember]
        public virtual int QuantitySold { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Avg Stars, no puede estar vacío")]
        [DataMember]
        public virtual float AvgStars { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
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
        public virtual IList<OrderDetail> OrderDetail { get; set; }
        public virtual IList<Rating> Rating { get; set; }
    }
}
