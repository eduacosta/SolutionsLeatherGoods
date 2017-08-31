using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class Dealer {
        public Dealer() {
			Product = new List<Product>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Category, no puede estar vacío")]
        public virtual Category Category { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Country, no puede estar vacío")]
        public virtual Country Country { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo First Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo First Name no debe ser mayor a 30 caracteres")]
        public virtual string FirstName { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Last Name, no puede estar vacío")]
        [Length(Max=30, Message="La longitud del campo Last Name no debe ser mayor a 30 caracteres")]
        public virtual string LastName { get; set; }
        [Length(Max=500, Message="La longitud del campo Description no debe ser mayor a 500 caracteres")]
        public virtual string Description { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Total Products, no puede estar vacío")]
        public virtual int TotalProducts { get; set; }
        public virtual System.Nullable<System.Guid> Rowid { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
        public virtual IList<Product> Product { get; set; }
    }
}
