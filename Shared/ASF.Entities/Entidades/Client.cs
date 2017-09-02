using System;
using System.Text;
using System.Collections.Generic;
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
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Country, no puede estar vacío")]
        public virtual Country Country { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo First Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo First Name no debe ser mayor a 30 caracteres")]
        public virtual string FirstName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Last Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Last Name no debe ser mayor a 30 caracteres")]
        public virtual string LastName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Email, no puede estar vacío")]
        [Length(Max=100, Message="La longitud del campo Email no debe ser mayor a 100 caracteres")]
        public virtual string Email { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Asp Net Users, no puede estar vacío")]
        [Length(Max=128, Message="La longitud del campo Asp Net Users no debe ser mayor a 128 caracteres")]
        public virtual string AspNetUsers { get; set; }
        [Length(Max=30, Message="La longitud del campo City no debe ser mayor a 30 caracteres")]
        public virtual string City { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Signup Date, no puede estar vacío")]
        public virtual DateTime SignupDate { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Order Count, no puede estar vacío")]
        public virtual int OrderCount { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
        public virtual IList<Order> Order { get; set; }
        public virtual IList<Rating> Rating { get; set; }
    }
}
