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
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Dealer, no puede estar vacío")]
        public virtual Dealer Dealer { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Title, no puede estar vacío")]
        [Length(Max=100, Message="La longitud del campo Title no debe ser mayor a 100 caracteres")]
        public virtual string Title { get; set; }
        [Length(Max=250, Message="La longitud del campo Description no debe ser mayor a 250 caracteres")]
        public virtual string Description { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Image, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Image no debe ser mayor a 30 caracteres")]
        public virtual string Image { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Price, no puede estar vacío")]
        public virtual float Price { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Quantity Sold, no puede estar vacío")]
        public virtual int QuantitySold { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Avg Stars, no puede estar vacío")]
        public virtual float AvgStars { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual IList<OrderDetail> OrderDetail { get; set; }
        public virtual IList<Rating> Rating { get; set; }
    }
}
