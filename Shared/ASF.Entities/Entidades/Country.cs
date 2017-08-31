using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace ASF.Entities {
    
    public class Country {
        public Country() {
			Client = new List<Client>();
			Dealer = new List<Dealer>();
        }
        public virtual int Id { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Name, no puede estar vacío")]
        [Length(Max=60, Message="La longitud del campo Name no debe ser mayor a 60 caracteres")]
        public virtual string Name { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Created On, no puede estar vacío")]
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? CreatedBy { get; set; }
        [NotNull(Message="Se debe cargar algún valor para el campo Changed On, no puede estar vacío")]
        public virtual DateTime ChangedOn { get; set; }
        public virtual int? ChangedBy { get; set; }
        public virtual IList<Client> Client { get; set; }
        public virtual IList<Dealer> Dealer { get; set; }
    }
}
