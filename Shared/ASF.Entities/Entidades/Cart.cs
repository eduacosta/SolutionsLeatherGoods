using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public virtual int Id { get; set; }
        [DataMember]
        [DisplayName("Cookie")]
        [NotNull(Message="Se debe cargar algún valor para el campo Cookie, no puede estar vacío")]
        [Length(Max=40, Message="La longitud del campo Cookie no debe ser mayor a 40 caracteres")]
        public virtual string Cookie { get; set; }
        [DataMember]
        [DisplayName("Cart Date")]
        [NotNull(Message="Se debe cargar algún valor para el campo Cart Date, no puede estar vacío")]
        public virtual DateTime CartDate { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Item Count, no puede estar vacío")]
        [DataMember]
        [DisplayName("Item Count")]
        public virtual int ItemCount { get; set; }
        [DataMember]
        [DisplayName("Rowid")]
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        [DisplayName("Created On")]
        public virtual DateTime CreatedOn { get; set; }
        [DataMember]
        [DisplayName("Created By")]
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        [DataMember]
        [DisplayName("Changed On")]
        public virtual DateTime ChangedOn { get; set; }
        [DataMember]
        [DisplayName("Changed By")]
        public virtual string ChangedBy { get; set; }

        public virtual bool? Eliminado { get; set; }
        public virtual IList<CartItem> CartItem { get; set; }
    }
}
