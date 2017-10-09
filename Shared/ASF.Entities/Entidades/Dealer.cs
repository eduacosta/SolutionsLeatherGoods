using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Dealer : EntityBase
    {
        public Dealer() {
			Product = new List<Product>();
        }

        [DataMember]
        [DisplayName("Id")]
        public virtual int Id { get; set; }

        [DataMember]
        [DisplayName("Category")]
        [NotNull(Message="Se debe cargar algún valor para el campo Category, no puede estar vacío")]
        public virtual Category Category { get; set; }

        public virtual int CategoryId { get; set; }

        [DataMember]
        [DisplayName("Country")]
        [NotNull(Message="Se debe cargar algún valor para el campo Country, no puede estar vacío")]
        public virtual Country Country { get; set; }

        public virtual int CountryId { get; set; }

        [DataMember]
        [DisplayName("FirstName")]
        [NotNull(Message="Se debe cargar algún valor para el campo First Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo First Name no debe ser mayor a 30 caracteres")]
        public virtual string FirstName { get; set; }

        [DataMember]
        [DisplayName("LastName")]
        [NotNull(Message="Se debe cargar algún valor para el campo Last Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Last Name no debe ser mayor a 30 caracteres")]
        public virtual string LastName { get; set; }
        [Length(Max=500, Message="La longitud del campo Description no debe ser mayor a 500 caracteres")]

        [DataMember]
        [DisplayName("Descripcion")]
        public virtual string Description { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Total Products, no puede estar vacío")]

        [DataMember]
        [DisplayName("TotalProducts")]
        public virtual int TotalProducts { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        [DataMember]
        [DisplayName("CreateOn")]
        public virtual DateTime CreatedOn { get; set; }

        [DataMember]
        [DisplayName("CreateBy")]
        public virtual string CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]

        [DataMember]
        [DisplayName("ChangedOn")]
        public virtual DateTime ChangedOn { get; set; }

        [DataMember]
        [DisplayName("ChangedBy")]
        public virtual string ChangedBy { get; set; }


        [DataMember]
        public virtual string AsPNetUsers { get; set; }

        public virtual IList<Product> Product { get; set; }
    }
}
