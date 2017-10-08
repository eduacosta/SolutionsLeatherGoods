using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    [Serializable]
    [DataContract]
    public class Client : EntityBase
    {
        public Client() {
			Order = new List<Order>();
			Rating = new List<Rating>();
        }
        [DataMember]
        [DisplayName("Id")]
        //[Browsable(false)]
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Country, no puede estar vacío")]
        [DataMember]
        [DisplayName("Country Id")]

       

        public virtual Country Country { get; set; }

        [DataMember]
        public virtual int CountryID { get; set; }

        [NotNull(Message="Se debe cargar algún valor para el campo First Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo First Name no debe ser mayor a 30 caracteres")]
        [DataMember]
        [DisplayName("First Name")]
        public virtual string FirstName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Last Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Last Name no debe ser mayor a 30 caracteres")]
        [DataMember]
        [DisplayName("Last Name")]
        public virtual string LastName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Email, no puede estar vacío")]
        [Length(Max=100, Message="La longitud del campo Email no debe ser mayor a 100 caracteres")]
        [DataMember]
        [DisplayName("Email")]
        public virtual string Email { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Users, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Users no debe ser mayor a 128 caracteres")]
        [DataMember]
        [DisplayName("Asp Net Users")]
        public virtual string AspNetUsers { get; set; }
        [Length(Max=30, Message="La longitud del campo City no debe ser mayor a 30 caracteres")]
        [DataMember]
        [DisplayName("City")]
        public virtual string City { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Signup Date, no puede estar vacío")]
        [DataMember]
        [DisplayName("Signup Date")]
        public virtual DateTime SignupDate { get; set; }
        [DataMember]
        [DisplayName("Rowid")]
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Order Count, no puede estar vacío")]
        [DataMember]
        [DisplayName("Order Count")]
        public virtual int OrderCount { get; set; }
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
        public virtual IList<Order> Order { get; set; }
        public virtual IList<Rating> Rating { get; set; }
    }
}
